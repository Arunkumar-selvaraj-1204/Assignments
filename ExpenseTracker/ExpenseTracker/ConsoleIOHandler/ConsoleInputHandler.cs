using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;
using ExpenseTracker.Utils;

namespace ExpenseTracker.ConsoleIOHandler
{
    public class ConsoleInputHandler
    {
        public int GetUserChoice()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                ConsoleOutputHandler.PrintInvalidOption("");
                Console.Write("Enter choice: ");
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

        public Expense GetExpenseDetails()
        {
            string category = GetCategory();
            DateOnly date = GetDate();
            double amount = GetAmount();
            return new Expense(category, date, amount);
        }

        public int GetIndex(string operation)
        {
            Console.Write($"Select record to {operation}: ");
            string userInput = Console.ReadLine();
            int index;
            while (!int.TryParse(userInput, out index) || index <= 0)
            {
                ConsoleOutputHandler.PrintInvalidOption("");
                Console.Write($"Select record to {operation}: ");
                userInput = Console.ReadLine();
            }
            return index;
        }

        public string GetIncomeSource()
        {
            Console.Write("Enter source of income: ");
            string incomeSource = Console.ReadLine();
            while (!InputValidator.IsValidSource(incomeSource))
            {
                Console.WriteLine("Invalid source details");
                Console.Write("Enter source of income: ");

                incomeSource = Console.ReadLine();
            }
            return incomeSource;
        }

        public string GetCategory()
        {
            Console.Write("Enter category of expense: ");
            string category = Console.ReadLine();
            while (!InputValidator.IsValidSource(category))
            {
                Console.WriteLine("Invalid category");
                Console.Write("Enter category of expense: ");

                category = Console.ReadLine();
            }
            return category;
        }

        public DateOnly GetDate()
        {
            Console.Write("Enter Date in YYYY-MM-DD: ");
            string date = Console.ReadLine();
            while (!InputValidator.IsValidDate(date))
            {
                Console.WriteLine("Invalid date format.");
                Console.Write("Enter Date in YYYY-MM-DD: ");
                date = Console.ReadLine();
            }
            return DateOnly.Parse(date);
        }

        public double GetAmount()
        {
            Console.Write("Enter amount: ");
            string amount = Console.ReadLine();
            while (!InputValidator.IsValidAmount(amount))
            {
                Console.WriteLine("Invalid amount. It should be greater than zero");
                Console.Write("Enter amount: ");

                amount = Console.ReadLine();
            }
            return double.Parse(amount);
        }
    }
}
