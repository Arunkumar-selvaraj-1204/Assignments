using UtilityApp;
using ProjectE;
using System.Runtime.CompilerServices;
namespace DisplayApp
{
    public class Printer
    {
        private IMathHelper _mathematicalOperations;

        public Printer(IMathHelper mathematicalOperations)
        {
            _mathematicalOperations = mathematicalOperations;
            PerformMathematicalCalculation();
        }
        static void Main(string[] args)
        {
             
        }

        /// <summary>
        /// Perform Mathematical calculations
        /// </summary>
        public void PerformMathematicalCalculation()
        {
            bool isExit = false;
            Console.Write("Enter number 1 :");
            int firstNumber = Helper.GetInt();
            Console.Write("Enter number 2 :");
            int secondNumber = Helper.GetInt();
            while (!isExit)
            {
                int ans = 0;
                Console.Write("\n[1] Add\n[2] Subtract\n[3] Multiply\n[4] Divide\n[5] Exit\nEnter the choice :");
                string userChoice = Helper.GetString();
                switch (userChoice)
                {
                    case "1":
                        ans = _mathematicalOperations.Add(firstNumber, secondNumber);
                        break;
                    case "2":
                        ans = _mathematicalOperations.Subtract(firstNumber, secondNumber);
                        break;
                    case "3":
                        ans = _mathematicalOperations.Multiply(firstNumber, secondNumber);
                        break;
                    case "4":
                        ans = _mathematicalOperations.Divide(firstNumber, secondNumber);
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice !");
                        break;
                }
                if (!isExit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Answer is " + ans);
                    Console.ResetColor();
                }
            }
        }

    }
}
