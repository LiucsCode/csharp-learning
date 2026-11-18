namespace Lambda2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DoSomeCalc<int>((int x, int y) => { return x + y; }, 3, 4);

            //DoSomeCalc<int>((x,y) => { return x + y; }, 3, 4);

            DoSomeCalc((x, y) => { return x + y; }, 3, 4);

        }

        static void DoSomeCalc<T>(Func<T,T,T> func,T x,T y)
        {
            T res = func(x, y);

            Console.WriteLine(res);
        }
    }
}
