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
                Console.WriteLine("Invalid input!");
                Console.Write($"Enter the {parameter}: ");
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
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                Console.Write("Enter the salary: ");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

        public static void PrintEmployeeDetails(string name, string position, decimal salary, decimal bonus)
        {
            Console.WriteLine($"Name: {name} \nPosition: {position} \nSalary: {salary} \nBonus: {bonus}");
            Console.WriteLine("\n================\n");
        }
        public static int GetChoice()
        {
            Console.WriteLine("1. Manager \n2. Developer \n3. Exit");
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                Console.Write("Enter choice: ");
                Console.WriteLine("Enter a valid input");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }

    }

}
