namespace ConsoleApp委托3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDele<int> dele1 = new MyDele<int>(Add);

            int resAdd = dele1(100, 200);

            Console.WriteLine(resAdd);

            MyDele<double> dele2 = new MyDele<double>(Mul);

            double resMul = dele2(1.2, 1.2);

            Console.WriteLine(resMul);
        }

        static int Add(int x,int y)
        {
            return x + y;
        }

        static double Mul(double x,double y)
        {
            return x * y;
        }

    }

    delegate T MyDele<T>(T x, T y);//泛型委托
}
