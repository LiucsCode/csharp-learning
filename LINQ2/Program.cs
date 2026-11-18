namespace LINQ2
{
    internal class Program
    {

        //LINQ 常用扩展方法

        static void Main(string[] args)
        {

            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jim", Age = 33, Gender = true, Salary = 3000 });
            list.Add(new Employee { Id = 3, Name = "lily", Age = 35, Gender = false, Salary = 9000 });
            list.Add(new Employee { Id = 4, Name = "lucy", Age = 16, Gender = false, Salary = 2000 });
            list.Add(new Employee { Id = 5, Name = "kimi", Age = 25, Gender = true, Salary = 1000 });
            list.Add(new Employee { Id = 6, Name = "nancy", Age = 35, Gender = false, Salary = 8000 });
            list.Add(new Employee { Id = 7, Name = "zack", Age = 35, Gender = true, Salary = 8500 });
            list.Add(new Employee { Id = 8, Name = "jack", Age = 33, Gender = true, Salary = 8000 });

            /*

            IEnumerable<Employee> items = list.Where(e => e.Age > 30);

            foreach (Employee item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(list.Count());
            Console.WriteLine(list.Count(e => e.Age>30));

            Console.WriteLine(list.Count(e => e.Age > 30 && e.Gender == false));

            Console.WriteLine(list.Any(e => e.Age>30));
            Console.WriteLine(list.Any(e =>e.Age > 30 && e.Salary > 10000));

            Console.WriteLine();
            Console.WriteLine();


            IEnumerable<Employee> employees1 = list.OrderBy(e => e.Age);
            foreach (Employee item in employees1)
            {
                Console.WriteLine(item);
            }

            int[] ints = new int[] { 1, 467, 35, 14, 9, 5, 9, 3, 6 };
            IEnumerable<int> ints1 = ints.OrderBy(i => i);
            foreach (var item in ints1)
            {
                Console.WriteLine(item);
            }

            IEnumerable<Employee> employees2 = list.OrderByDescending(e => e.Name[e.Name.Length-1]);
            foreach(Employee item in employees2)
            {
                Console.WriteLine(item);
            }

            var items2 = list.OrderBy(e => e.Age).ThenByDescending(e => e.Salary);
            foreach (var item in items2)
            {

                Console.WriteLine(item);
            }

            Console.WriteLine();

            IEnumerable<Employee> employees3 = list.Skip(3).Take(3);
            foreach (var item in employees3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            IEnumerable<Employee> employees4 = list.Where(e => e.Age > 30).OrderBy(e => e.Salary).Skip(1).Take(2);
            foreach(var item in employees4)
            {
                Console.WriteLine(item);
            }

            */

            int a = list.Max(e => e.Age);
            Console.WriteLine(a);

            int b = list.Where(e => e.Id >= 6).Max(e => e.Salary);
            Console.WriteLine(b);

            string s = list.Max(e => e.Name);
            Console.WriteLine(s);


            IEnumerable<IGrouping<int, Employee>> groups = list.GroupBy(e => e.Age);
            foreach (IGrouping<int, Employee> group in groups)
            {
                Console.WriteLine($"年龄为{group.Key}的员工有：");
                foreach (Employee item in group)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("-------------------------------------------");

            IEnumerable<int> ages = list.Select(e => e.Age);
            foreach (int age in ages)
            {
                Console.WriteLine(age);
            }
            Console.WriteLine("-------------------------------------------");
            var groupStats = list.GroupBy(e => e.Age)
                .Select(g => new
                {
                    Age = g.Key,
                    MaxSalary = g.Max(emp => emp.Salary),
                    MinSalary = g.Min(equals => equals.Salary),
                    Count = g.Count()
                }
                );

            foreach (var stat in groupStats)
            {
                Console.WriteLine($"年龄为{stat.Age}的员工：");
                Console.WriteLine($"  最高工资：{stat.MaxSalary}");
                Console.WriteLine($"  最低工资：{stat.MinSalary}");
                Console.WriteLine($"  人数：{stat.Count}");
            }
        }
    }
}
