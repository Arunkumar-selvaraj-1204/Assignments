using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy
{
    internal class IOManager
    {
        public static string GetInput(string parameter)
        {
            Console.Write($"Enter the {parameter}: ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || userInput.Any(char.IsDigit))
            {
                Console.Write($"Enter the {parameter}: ");
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        public static decimal GetSalary()
        {
            Console.Write("Enter the salary: ");
            string userInput = Console.ReadLine();
            decimal parsedInput;
            while (!decimal.TryParse(userInput, out parsedInput))
            {
                Console.Write("Enter the salary: ");
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

        public static void PrintEmployeeDetails(string name, decimal salary)
        {
            Console.WriteLine($"Name: {name} \nSalary: {salary}");
        }
    
    }

}
