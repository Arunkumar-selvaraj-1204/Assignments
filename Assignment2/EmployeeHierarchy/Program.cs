using System.Reflection.Emit;

namespace EmployeeHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalaryCalculator calculator = new SalaryCalculator();
            Console.WriteLine("Select your role");
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = IOManager.GetChoice();
                switch (userChoice)
                {
                    case 1:
                        calculator.CalculateManagerSalary();
                        break;
                    case 2:
                        calculator.CalculateDeveloperSalary();
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
        }
    }
}
