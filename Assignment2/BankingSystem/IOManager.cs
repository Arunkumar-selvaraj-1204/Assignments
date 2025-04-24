using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class IOManager
    {
        public static int GetChoice(string choice1, string choice2)
        {
            Console.WriteLine($"1. {choice1} \n2. {choice2} \n3. Exit");
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write("Enter choice: ");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }

        public static string GetAccountNumber()
        {
            Console.Write("Enter Account number:");
            string userInput = Console.ReadLine();
            int userChoice;
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write("Enter Account number: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static decimal GetAmount(string parameter)
        {
            Console.Write($"Enter {parameter}:");
            string userInput = Console.ReadLine();
            decimal userBalance;
            while (!decimal.TryParse(userInput, out userBalance))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write($"Enter {parameter}: ");
                userInput = Console.ReadLine();
            }
            return userBalance;
        }
    }
}
