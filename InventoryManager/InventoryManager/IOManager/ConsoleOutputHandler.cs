using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Model;
using InventoryManager.Utils;
using static InventoryManager.Model.ApplicationEnums;


namespace InventoryManager.IOManager
{
    internal class ConsoleOutputHandler
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

        public static void PrintCurrentTask(Tasks task)
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

        public static void PrintErrorMessage(string message)
        {
            Utilities.PrintColorMessage(message, ConsoleColor.Red);
        }

        public static void ShowProductDetail(Product product, bool showChoice = false)
        {
            Console.WriteLine("--- Product Details ---");
            Console.WriteLine($"{(showChoice ? "1." : "")}Product ID:        {product.ProductId}");
            Console.WriteLine($"{(showChoice ? "2." : "")}Product Name:      {product.ProductName}");
            Console.WriteLine($"{(showChoice ? "3." : "")}Price:             ₹{product.Price:N2}");
            Console.WriteLine($"{(showChoice ? "4." : "")}Quantity in Stock: {product.QuantityInStock}");
            Console.WriteLine("-----------------------");
        }
    }
}
