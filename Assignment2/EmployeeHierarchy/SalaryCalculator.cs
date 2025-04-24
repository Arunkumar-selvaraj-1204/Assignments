using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    internal class SalaryCalculator
    {
        public void CalculateManagerSalary()
        {
            Manager manager = new Manager();
            manager.GetName();
            manager.GetSalary();
            manager.PrintDetails();
        }
        public void CalculateDeveloperSalary()
        {
            Developer developer = new Developer();
            developer.GetName();
            developer.GetSalary();
            developer.PrintDetails();

        }
    }
}
