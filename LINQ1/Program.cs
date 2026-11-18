namespace LINQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums =  { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //IEnumerable<int> result = nums.Where(a => a > 5);

            //IEnumerable<int> result = MyWhere1(nums, a => a > 5);

            IEnumerable<int> result = MyWhere2(nums, a => a > 5);


            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }

        //自己写的示例1
        static IEnumerable<int> MyWhere1(IEnumerable<int> items,Func<int,bool> f)
        {
            List<int> result = new List<int>();


            foreach (int i in items) {
                if(f(i) == true)
                {
                    result.Add(i);
                }
            }

            return result;
        }


        //自己写的示例2
        static IEnumerable<int> MyWhere2(IEnumerable<int> items, Func<int, bool> f)
        {
            
            foreach (int i in items)
            {
                if (f(i) == true)
                {
                    yield return i;
                }
            }

        }
    }
}
