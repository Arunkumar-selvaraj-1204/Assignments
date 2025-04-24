using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    internal abstract class Employee
    {
        public string name { get; set; }
        public decimal salary { get; set; }
        public abstract decimal CalculateSalary();
        public void PrintDetails()
        {
            Console.WriteLine("It is generic employee");
        }

    }
}
