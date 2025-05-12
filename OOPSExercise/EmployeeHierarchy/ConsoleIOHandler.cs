namespace EmployeeHierarchy
{
    internal class ConsoleIOHandler
    {
        /// <summary>
        /// Prompts the user to enter a valid string value for the specified prompt message.
        /// Ensures the input is non-empty and does not contain any digits.
        /// </summary>
        /// <param name="promptMessage">The prompt message being requested (e.g., "Name", "Position").</param>
        /// <returns>
        /// A valid string entered by the user.
        /// </returns>
        public static string GetInput(string promptMessage)
        {
            Console.Write($"Enter the {promptMessage}: ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || userInput.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid input!");
                Console.Write($"Enter the {promptMessage}: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        /// <summary>
        /// Prompts the user to enter a valid salary amount.
        /// Ensures the input is a valid decimal or integer value.
        /// </summary>
        /// <returns>
        /// A decimal value representing the user's salary.
        /// </returns>
        public static decimal GetSalary()
        {
            Console.Write("Enter the salary: ");
            string userInput = Console.ReadLine();
            decimal parsedInput;
            while (!decimal.TryParse(userInput, out parsedInput))
            {
                Console.WriteLine("Invalid input! Please enter a decimal or integer.");
                Console.Write("Enter the salary: ");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

        /// <summary>
        /// Prints the details of an employee, including name, position, salary, and bonus.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="position">The position of the employee (e.g., "Manager", "Developer").</param>
        /// <param name="salary">The salary of the employee as a decimal value.</param>
        /// <param name="bonus">The bonus amount of the employee as a decimal value.</param>

        public static void PrintEmployeeDetails(string name, string position, decimal salary, decimal bonus)
        {
            Console.WriteLine($"Name: {name} \nPosition: {position} \nSalary: {salary} \nBonus: {bonus}");
            Console.WriteLine("\n================\n");
        }

        /// <summary>
        /// Displays a menu of choices (e.g., "Manager", "Developer", "Exit") and gets the user's input as an integer.
        /// </summary>
        /// <returns>
        /// An integer representing the user's choice:
        /// </returns>
        public static int GetChoice()
        {
            Console.WriteLine("1. Manager \n2. Developer \n3. Exit");
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write("Enter choice: ");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }
        
        /// <summary>
        /// Gets the bonus percentage for the employee
        /// </summary>
        /// <returns>Bonus percentage</returns>
        public static decimal GetBonusPercentage()
        {
            Console.Write("Enter bonus percentage %: ");
            string userInput = Console.ReadLine();
            decimal bonus;
            while (!decimal.TryParse(userInput, out bonus))
            {
                Console.WriteLine("Enter a valid input");
                Console.Write("Enter Bonus percentage %: ");
                userInput = Console.ReadLine();
            }
            return bonus/100;

        }

    }

}
