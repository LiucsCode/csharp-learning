using System.Threading.Tasks;

namespace AsyncAwaitApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string fileName = @"F:\test\1.txt";

            File.Delete(fileName);

            await DownloadHtmlAsync("https://blog.csdn.net/weixin_46872121/article/details/141784731", fileName);

            Console.WriteLine("ok");
        }


        /// <summary>
        /// 读取网页html内容写入文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static async Task DownloadHtmlAsync(string url , string fileName)
        {
            using (HttpClient httpClient = new HttpClient())//using 语句确保 HttpClient 对象在代码块结束时自动调用 Dispose()，及时释放它占用的非托管资源（主要是底层的网络连接和 socket），即使 await 过程中抛出异常也保证释放。
            {
                string html = await httpClient.GetStringAsync(url);
                await File.WriteAllTextAsync(fileName, html);
            }
        }

    }
}
