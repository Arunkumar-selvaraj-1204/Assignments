using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Utils;

namespace InventoryManager.IOManager
{
    internal class OutputManager
    {
        public static void PrintInitialMenu()
        {
            Console.WriteLine("\n1. Add new product \n2. View all products \n3. Search product \n4. Edit product details \n5. Delete Product \n6. Exit");
        }

        public static void PrintInvalidOption(string validFormat)
        {
            Console.WriteLine($"Invalid option. {validFormat}");
        }
        public static void PrintInvalidInput(string validFormat)
        {
            Utilities.PrintColorMessage("Invalid Input!", ConsoleColor.Red);
            Console.WriteLine(validFormat);
        }

        public static void PrintCurrentTask(string task)
        {
            Console.WriteLine($"----- {task} PRODUCT -----");
        }

        public static void ClearConsoleAndPrintMenu()
        {
            Console.Clear();
            PrintInitialMenu();
        }

        public static void PrintSuccessMessage(string message)
        {
            Utilities.PrintColorMessage(message, ConsoleColor.Green);
        }
    }
}
