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
        /// <summary>
        /// Displays a menu with two options and an exit option, and gets the user's choice as an integer.
        /// </summary>
        /// <param name="choice1">The first choice to display to the user.</param>
        /// <param name="choice2">The second choice to display to the user.</param>
        /// <returns>
        /// An integer representing the user's choice:
        /// </returns>
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

        /// <summary>
        /// Prompts the user to enter an account number and ensures the input is valid (non-empty).
        /// </summary>
        /// <returns>
        /// A string representing the valid account number entered by the user.
        /// </returns>
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

        /// <summary>
        /// Prompts the user to enter a decimal value for the specified parameter and ensures the input is valid.
        /// </summary>
        /// <param name="promptMessage">The prompt message being entered (e.g., "Balance", "Deposit Amount").</param>
        /// <returns>
        /// A decimal representing the valid amount entered by the user.
        /// </returns>
        public static decimal GetAmount(string promptMessage)
        {
            Console.Write($"Enter {promptMessage}:");
            string userInput = Console.ReadLine();
            decimal userBalance;
            while (!decimal.TryParse(userInput, out userBalance))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write($"Enter {promptMessage}: ");
                userInput = Console.ReadLine();
            }
            return userBalance;
        }
    }
}
