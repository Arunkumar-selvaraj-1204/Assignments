using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal class InputManager
    {
        /// <summary>
        /// Prompts the user to enter a numeric value for the specified prompt message and validates the input.
        /// </summary>
        /// <param name="promptMessage">The prompt message being requested (e.g., "Length", "Width", "Radius").</param>
        /// <returns>A valid double value entered by the user.</returns>
        public static double GetInput(string promptMessage)
        {
            Console.Write($"Enter the {promptMessage}: ");
            string userInput = Console.ReadLine();
            double parsedInput;
            while (!double.TryParse(userInput , out parsedInput) ) {
                Console.Write($"Enter the {promptMessage}: ");
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

        /// <summary>
        /// Prompts the user to enter a valid color and ensures it is non-empty and does not contain digits.
        /// </summary>
        /// <returns>A valid color string entered by the user.</returns>
        public static string GetColor()
        {
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(color) || color.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid Color");
                Console.Write("Enter color: ");
                color = Console.ReadLine();
            }
            return color;
        }

        /// <summary>
        /// Displays a menu of options and prompts the user to select a choice as an integer.
        /// </summary>
        /// <returns>
        /// An integer representing the user's choice.
        /// </returns>
        public static int GetChoice()
        {
            Console.WriteLine("1. Create rectangle \n2. Create circle \n3. Exit");
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while(!int.TryParse(userInput , out userChoice))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write("Enter choice: ");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }
    }
}
