using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal class InputManager
    {
        public static double GetInput(string parameter)
        {
            Console.Write($"Enter the {parameter}: ");
            string userInput = Console.ReadLine();
            double parsedInput;
            while (!double.TryParse(userInput , out parsedInput) ) {
                Console.Write($"Enter the {parameter}: ");
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

        public static string GetColor()
        {
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(color))
            {
                Console.Write("Enter color: ");
                color = Console.ReadLine();
            }
            return color;
        }

        public static int GetChoice()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while(!int.TryParse(userInput , out userChoice))
            {
                Console.Write("Enter choice: ");
                Console.WriteLine("Enter a valid input");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }
    }
}
