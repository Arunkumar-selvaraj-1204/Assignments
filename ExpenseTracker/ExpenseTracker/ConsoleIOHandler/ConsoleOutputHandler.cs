using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;

namespace ExpenseTracker.ConsoleIOHandler
{
    public class ConsoleOutputHandler
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine("-----Expense Tracker-----");
            Console.WriteLine("1. Track Income \n2. Track Expense \n3. Financial summary \n4. Exit");
        }
        public static void PrintInvalidOption(string validFormat)
        {
            Console.WriteLine($"Invalid option. {validFormat}");
        }
        public static void DisplayIncomeChoice()
        {
            Console.WriteLine("-----Income operations-----");
            Console.WriteLine("1. Add Income \n2. Edit Income \n3. Delete Income \n4. Show All Income \n5. Main Menu ");
        }
        public static void DisplayExpenseChoice()
        {
            Console.WriteLine("-----Expense operations-----");
            Console.WriteLine("1. Add Expense \n2. Edit Expense \n3. Delete Expense \n4. Show All Expense \n5. Main Menu ");
        }
        public static void PrintAllIncome(List<Income> incomeList)
        {
            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-10}", "No.", "Source", "Date", "Amount");
            Console.WriteLine(new string('-', 60));

            int count = 1;
            foreach (Income income in incomeList)
            {
                Console.WriteLine(
                    "{0,-5} | {1,-20} | {2,-15} | {3,-10:C}",
                    count++,
                    income.Source,
                    income.Date.ToString("yyyy-MM-dd"),
                    income.Amount
                );
            }
        }
        public static void PrintAllExpense(List<Expense> expenseList)
        {
            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-10}", "No.", "Category", "Date", "Amount");
            Console.WriteLine(new string('-', 60));

            int count = 1;
            foreach (Expense expense in expenseList)
            {
                Console.WriteLine(
                    "{0,-5} | {1,-20} | {2,-15} | {3,-10:C}",
                    count++,
                    expense.Category,
                    expense.Date.ToString("yyyy-MM-dd"),
                    expense.Amount
                );
            }
        }

        public static void PrintIncomeDetails(Income income)
        {
            Console.WriteLine($"1. Source: {income.Source} \n2. Date: {income.Date} \n3. Amount: {income.Amount}");
        }
        public static void PrintExpenseDetails(Expense expense)
        {
            Console.WriteLine($"1. Source: {expense.Category} \n2. Date: {expense.Date} \n3. Amount: {expense.Amount}");
        }
        public static void PrintFinancialSummary(double income, double expense)
        {
            Console.Write($"Total income: {income} \nTotal expense: {expense} \nNet balance: ");
            if(income - expense < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"{income - expense}");
            Console.ResetColor();
        }
        public static Object PrintBalance(double balance, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{balance}");
            Console.ResetColor();
            return null;
        }
    }
}
