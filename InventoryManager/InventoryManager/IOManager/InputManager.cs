using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManager.IOManager
{
    internal class InputManager
    {

        public static int GetUserChoice()
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
    }
}
