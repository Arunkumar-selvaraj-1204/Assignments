using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingSystem
{
    public class LoggerUtils
    {
        public static int ReadChoice()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
                    return choice;

                Console.Write("Invalid choice. Please enter 1 or 2: ");
            }
        }

        public static int ReadIntInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number > 0)
                    return number;

                Console.Write("Please enter a valid positive number: ");
            }
        }
    }
}
