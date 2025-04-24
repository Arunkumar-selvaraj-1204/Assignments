using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    internal class Manager : Employee
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
            return salary * (decimal) 0.05;
        }

        public void PrintDetails()
        {
            IOManager.PrintEmployeeDetails(name, "Manager", salary, CalculateBonus());
        }
    }
}
