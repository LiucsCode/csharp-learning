namespace ConsoleApp委托
{
    internal class Program
    {
        //一个函数或者一组函数的封装器
        //委托声明时要与“包裹”函数的返回值和参数类型一致

        static void Main(string[] args)
        {
            MyDele dele = new MyDele(M1); //dele变量引用着一个MyDele类型的实例，这个实例“包裹”着M1这个方法。

            //dele = dele + M1; 加上M1，多调用一次

            dele.Invoke();
        }

        static void M1()
        {
            Console.WriteLine("M1 is called!");
        }
    }

    delegate void MyDele(); //声明一个能封装 （void 返回值 空参 的 函数） 的委托

}