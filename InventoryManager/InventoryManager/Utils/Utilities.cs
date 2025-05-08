using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Utils
{
    internal class Utilities
    {
        /// <summary>
        /// Prints a message to the console in the specified color and resets the color to white afterward.
        /// </summary>
        /// <param name="message">The message to be printed to the console.</param>
        /// <param name="color">The <see cref="ConsoleColor"/> to use for the message text.</param>
        public static void PrintColorMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
