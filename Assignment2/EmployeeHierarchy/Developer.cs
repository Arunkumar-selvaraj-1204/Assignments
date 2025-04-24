using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeHierarchy
{
    internal class Developer : Employee
    {
        public void GetName()
        {
            name = IOManager.GetInput("name");
        }
        public void GetSalary()
        {
            salary = IOManager.GetSalary();
        }

        public override decimal CalculateBonus()
        {
            return salary * (decimal)0.02;
        }

        public void PrintDetails()
        {
            IOManager.PrintEmployeeDetails(name, "Developer", salary, CalculateBonus());
        }
    }
}
