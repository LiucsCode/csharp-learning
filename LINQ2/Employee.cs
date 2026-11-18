using LINQ2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2
{
    internal class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }

        public int Salary { get; set; }

        public override string ToString()//自定义该对象在转换为字符串时的输出格式
        {
            return $"Id={Id}, Name={Name}, Age={Age}, Gender={Gender}, Salary={Salary}";
        }


    }


}
