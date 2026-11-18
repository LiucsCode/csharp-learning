namespace ConsoleApp委托4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(M1);//无返回值,无参数
            action();

            Action<string> action1 = new Action<string>(SayHello);//无返回值,有参数
            action1("Tom");

            Func<int> func = new Func<int>(M2);//有返回值，无参数
            Console.WriteLine(func());

            Func<int, int, int> func1 = new Func<int, int, int>(Add);//有返回值，有参数
            int resAdd = func1(100,200);
            Console.WriteLine(resAdd);

            Func<double,double,double> func2 = new Func<double,double,double>(Mul);
            double resMul = func2(1.3,1.3);
            Console.WriteLine(resMul);
        }

        static void M1()
        {
            Console.WriteLine("M1 is called!");
        }

        static int M2() {
            return 200;
        }

        static void SayHello(string name)
        {
            Console.WriteLine($"hello,{name}");
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }

    }
}
