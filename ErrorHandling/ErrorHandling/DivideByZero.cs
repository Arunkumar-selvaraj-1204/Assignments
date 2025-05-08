using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static ErrorHandling.ApplicationEnums;

namespace ErrorHandling
{
    internal class DivideByZero
    {
        public DivideByZero() {
            Console.WriteLine("helooo");
           int dividend =  GetInput(DivisionInput.dividend);
            int divisor = GetInput(DivisionInput.divisor);
            divideNumbers(dividend, divisor);
        }
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
