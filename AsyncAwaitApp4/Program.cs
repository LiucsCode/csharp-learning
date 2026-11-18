namespace AsyncAwaitApp4
{
    internal class Program
    {
        // lambda表达式中使用异步
        static void Main(string[] args)
        {

            string fileName = @"F:\test\1.txt";

            File.Delete(fileName);


            ThreadPool.QueueUserWorkItem(async (obj) =>
            {
                while (true)
                {
                    await File.WriteAllTextAsync(fileName, "hello world!");

                    Console.WriteLine("ok");
                }
            });
            Console.Read();

            
        }
    }
}
