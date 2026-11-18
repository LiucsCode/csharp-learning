using System.Threading.Tasks;

namespace CancellationTokenStudy
{
    internal class Program
    {
        // 【主题】CancellationToken：.NET 的"协作式取消"机制。
        // 它本身不会强行杀掉线程/任务，只是提供一个"取消信号"，
        // 由被调用方在合适的时机主动检查并退出。
        static async Task Main(string[] args)
        {
            // 1) CancellationTokenSource 是"取消信号的发射器"，负责发起取消
            CancellationTokenSource cts = new CancellationTokenSource();

            // 2) 5 秒后自动触发取消（内部起一个定时器）
            //    等价写法：new CancellationTokenSource(5000)
            cts.CancelAfter(5000);

            // 3) Token 是"信号凭证"，从 Source 取出后往下传；
            //    Token 只能读状态（IsCancellationRequested），不能主动取消
            CancellationToken cToken = cts.Token;

            // 4) 三种取消写法对比，每次只放开一个：
            //    Download1 —— 轮询判断 + break，最"钝"的做法
            //    Download2 —— 轮询判断 + 抛异常，能被上层感知
            //    Download3 —— Token 直达网络层，真正中断请求（推荐）
            //await Download1Async("https://www.baidu.com", 100, cToken);
            //await Download2Async("https://www.baidu.com", 100, cToken);
            await Download3Async("https://www.baidu.com", 100, cToken);
        }

        /// <summary>
        /// 方式一：请求完成后用 IsCancellationRequested 判断，然后 break。
        /// 缺点：① Token 没传给 HttpClient，正在飞行的请求无法被中断，
        ///       必须等当前请求自己返回才可能退出，取消粒度很粗；
        ///       ② break 是"静默退出"，调用方无法区分"正常跑完"和"被取消"。
        /// </summary>
        static async Task Download1Async(string url, int n, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())  // HttpClient 建议复用，见文末说明
            {
                for (int i = 0; i < n; i++)   // 循环 n 次，模拟重复下载
                {
                    // 注意：GetStringAsync 没有接收 Token —— 这一步不可取消
                    string html = await client.GetStringAsync(url);

                    Console.WriteLine($"{DateTime.Now}:{html}");  // 打印整页 HTML，输出量极大

                    // 检查取消信号：只有在"上一次请求已经返回"之后才检查得到
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("请求被取消");
                        break;   // 只跳出循环，方法正常 return，异常栈里看不到"已取消"
                    }
                }
            }
        }

        /// <summary>
        /// 方式二：用 ThrowIfCancellationRequested() 抛异常来中断。
        /// 已请求取消时抛出 OperationCanceledException，
        /// 能沿 await 链向上冒泡，调用方可以 catch 到并做善后。
        /// 缺点：同样没把 Token 传给 HttpClient，仍要等当前请求返回才抛。
        /// </summary>
        static async Task Download2Async(string url, int n, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await client.GetStringAsync(url);   // 依旧不可取消
                    Console.WriteLine($"{DateTime.Now}:{html}");

                    // 若 Token 已取消 → 立即抛 OperationCanceledException
                    // 等价于：if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }

        /// <summary>
        /// 方式三：把 Token 一路传进 HttpClient.GetAsync（推荐做法）。
        /// 5 秒到点时，底层 Socket/连接会被真正中止，
        /// 抛出的 TaskCanceledException 是 OperationCanceledException 的子类，
        /// 无需等当前请求自然结束，响应最及时。
        /// </summary>
        static async Task Download3Async(string url, int n, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    // ★ 关键：Token 交给网络层，取消可"穿透"到 IO 操作
                    var resp = await client.GetAsync(url, cancellationToken);

                    // 读到完整响应体（也可用带 Token 的重载 ReadAsStringAsync(cancellationToken)）
                    string html = await resp.Content.ReadAsStringAsync();

                    Console.WriteLine($"{DateTime.Now}:{html}");
                }
            }
        }
    }
}
