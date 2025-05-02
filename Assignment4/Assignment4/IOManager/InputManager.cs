using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;
using ExpenseTracker.Utils;

namespace ExpenseTracker.IOManager
{
    internal class InputManager
    {
        public int GetUserChoice()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                OutputManager.PrintInvalidOption("");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }
        
        public Income GetIncomeDetails()
        {
            string source = GetIncomeSource();
            DateOnly date = GetDate();
            double amount = GetAmount();
            return new Income(source, date, amount);
        }


        private string GetIncomeSource()
        {
            Console.Write("Enter source of income: ");
            string incomeSource = Console.ReadLine();
            while (!Validator.IsValidSource(incomeSource))
            {
                Console.WriteLine("Invalid source details");
                Console.Write("Enter source of income: ");

                incomeSource = Console.ReadLine();
            }
            return incomeSource;
        }

        private DateOnly GetDate()
        {
            Console.Write("Enter Date in YYYY-MM-DD: ");
            string date = Console.ReadLine();
            while (!Validator.IsValidDate(date))
            {
                Console.WriteLine("Invalid date format.");
                Console.Write("Enter Date in YYYY-MM-DD: ");
                date = Console.ReadLine();
            }
            return DateOnly.Parse(date);
        }

        private double GetAmount()
        {
            Console.Write("Enter amount: ");
            string amount = Console.ReadLine();
            while (!Validator.IsValidAmount(amount))
            {
                Console.WriteLine("Invalid amount. It should be greater than zero");
                Console.Write("Enter amount: ");

                amount = Console.ReadLine();
            }
            return double.Parse(amount);
        }
    }
}
