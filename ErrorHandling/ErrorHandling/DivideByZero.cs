using static ErrorHandling.ApplicationEnums;

namespace ErrorHandling
{
    internal class DivideByZero
    {
        public DivideByZero() {
           int dividend =  GetInput(DivisionInput.dividend);
            int divisor = GetInput(DivisionInput.divisor);
            divideNumbers(dividend, divisor);
        }

        /// <summary>
        /// Gets input for the division component.
        /// </summary>
        /// <param name="input">The division component (dividend or divisor).</param>
        /// <returns>The valid integer input provided by the user.</returns>
        public int GetInput(DivisionInput input)
        {
            Console.Write($"Enter {input}: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("Invalid number! Enter an integer");
                Console.Write($"Enter {input}: ");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }

        /// <summary>
        /// Divides two numbers and handles division by zero exceptions.
        /// </summary>
        /// <param name="dividend">The number to be divided.</param>
        /// <param name="divisor">The number to divide by.</param>
        public void divideNumbers(int dividend, int divisor)
        {
            try
            {
                double result = dividend / divisor;
                Console.WriteLine($"Quotient is {result}");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Divisor cannot be ZERO");
            }
            finally
            {
                Console.WriteLine("Finally block has been successfully executed!☺");
                Utils.PressKeyToContinue();
            }
        }
    }
}
