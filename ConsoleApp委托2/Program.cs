namespace ConsoleApp委托2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDele dele = new MyDele(Add);

            int res = dele(100,200);

            Console.WriteLine(res);
        }

        static int Add(int x, int y) { return x + y; }
    }



    delegate int MyDele(int a, int b);

}
