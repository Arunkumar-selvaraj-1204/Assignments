using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.IOManager
{
    public class OutputManager
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
            Console.WriteLine("1. Add Income \n2. Edit Income \n3. Delete Income \n4. Show All Income \n3. Main Menu ");
        }
    }
}
