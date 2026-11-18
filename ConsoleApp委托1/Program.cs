namespace ConsoleApp委托1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDele dele = new MyDele(M1);

            dele = dele + (new Student()).SayHello; //调用类中方法

            dele();// = dele.Invoke();
        }

        static void M1()
        {
            Console.WriteLine("M1 is called!");
        }

    }

    class Student
    {
        public void SayHello()
        {
            Console.WriteLine("hello world!");
        }
    }

    delegate void MyDele();

}
