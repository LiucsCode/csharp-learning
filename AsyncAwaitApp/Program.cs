using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    internal class Program
    {
        //异步编程 await async
        /*
         * 1.异步方法的返回值一般是Task<T>，T是真正的返回值类型。异步方法命名以Async结尾
         * 2.即使方法没有返回值，也最好将返回值声明为Task
         * 3.调用泛型方法时，一般在方法前加上await,这样拿到的返回值就是泛型指定的T类型
         * 4.异步方法的“传染性”:一个方法中如果有await调用，则这个方法也必须修饰为async
         * 
         * await 代码中使用 加上之后会等待方法执行完毕
         * async 修饰方法
         * Task  修饰方法
         */
        static async Task Main(string[] args)
        {
            string fileName = @"F:\test\1.txt";
            
            File.Delete(fileName);

            await File.WriteAllTextAsync(fileName, "hello world");

            string str = await File.ReadAllTextAsync(fileName);

            Console.WriteLine(str);
        }

        


    }
}
