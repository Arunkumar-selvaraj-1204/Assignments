using UtilityApp;
using MathApp;
namespace DisplayApp
{
    public class Printer
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// Perform Mathematical calculations
        /// </summary>
        public static void PerformMathematicalCalculation()
        {
            bool isExit = false;
            Console.Write("Enter number 1 :");
            int num1 = Helper.GetInt();
            Console.Write("Enter number 2 :");
            int num2 = Helper.GetInt();
            while (!isExit)
            {
                int ans = 0;
                Console.WriteLine("\n[1] Add\n[2] Subtract\n[3] Multiply\n[4] Divide\n[5] Exit\nEnter the choice :");
                string userChoice = Helper.GetString();
                switch (userChoice)
                {
                    case "1":
                        ans = MathematicalOperations.Add(num1, num2);
                        break;
                    case "2":
                        ans = MathematicalOperations.Subtract(num1, num2);
                        break;
                    case "3":
                        ans = MathematicalOperations.Multiply(num1, num2);
                        break;
                    case "4":
                        ans = MathematicalOperations.Divide(num1, num2);
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice !");
                        break;
                }
                Console.WriteLine("Answer is " + ans);
            }
        }

    }
}
