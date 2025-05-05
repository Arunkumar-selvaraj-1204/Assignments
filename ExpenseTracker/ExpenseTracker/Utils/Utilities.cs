using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Utils
{
    internal class Utilities
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public static void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message} successfully");
            Console.ForegroundColor = ConsoleColor.White;
            PressAnyKey();
        }
        public static void PrintNoRecords(string transactionType)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"No {transactionType} records found!");
            Console.ForegroundColor = ConsoleColor.White;
            PressAnyKey();
        }
    }
}
