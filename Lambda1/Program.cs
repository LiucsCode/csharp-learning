namespace Lambda1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> func = new Func<int, int, int>(( x, y) => { return x + y; });

            ///
            /// (int x,int y) => { return x + y; }
            /// 
            /// (int x,int y)
            /// { return x + y; }
            ///

            int res = func(100,200);

            Console.WriteLine(res);

            func = new Func<int, int, int>(( a, b) => { return a * b; });
            res = func(3,4);

            Console.WriteLine(res);
        }
    }
}
