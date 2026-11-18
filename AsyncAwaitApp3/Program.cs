namespace AsyncAwaitApp3
{
    internal class Program
    {
        //对于不支持 await async 的异步方法： Wait() （无返回值）；Result （有返回值）
        static void Main(string[] args)
        {
            string fileName = @"F:\test\1.txt";

            //1.Result

            Task<string> str = File.ReadAllTextAsync(fileName);
            string s1 = str.Result; //Result （有返回值）

            //string s2 = File.ReadAllTextAsync(fileName).Result;

            //2.Wait()
            File.WriteAllTextAsync(fileName, "1111111111111111").Wait();
        }
    }
}
