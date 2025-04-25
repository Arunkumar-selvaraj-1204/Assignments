using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.IOManager
{
    internal class OutputManager
    {
        public static void PrintInitialMenu()
        {
            Console.WriteLine("\n1. Add new product \n2. View all products \n3. Search product \n4. Edit product details \n5. Delete Product \n6. Exit");
        }

        public static void PrintInvalidOption(string format)
        {
            Console.WriteLine($"Invalid option. {format}");
        }
    }
}
