using System;
using System.Collections.Generic;
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

        public static void PrintIncomeDetails(Income income)
        {
            Console.WriteLine($"1. Source: {income.Source} \n2. Date: {income.Date} \n3. Amount: {income.Amount}");
        }
    }
}
