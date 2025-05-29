using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderTheHood
{
    /// <summary>
    /// Perform basic arithmetic operations
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// First number
        /// </summary>
        public int FirstNumber { get; set; }

        /// <summary>
        /// Second number
        /// </summary>
        public int SecondNumber { get; set; }

        /// <summary>
        /// Constructor to initialize firstNumber and B
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second Number</param>
        public MathUtils(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        /// <summary>
        /// Initialize all the methods
        /// </summary>
        public void ExecuteOperations()
        {
            Console.WriteLine($"addition of {FirstNumber} and {SecondNumber} is {add(FirstNumber, SecondNumber)}");
            Console.WriteLine($"Subtraction of {FirstNumber} and {SecondNumber} is {Subtract(FirstNumber, SecondNumber)}");
            Console.WriteLine($"Multiplication of {FirstNumber} and {SecondNumber} is {Multiply(FirstNumber, SecondNumber)}");
            Console.WriteLine($"Division of {FirstNumber}  and  {SecondNumber} is {Divide(FirstNumber, SecondNumber)}");
        }

        /// <summary>
        /// add two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private int add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private int Divide(int firstNumber, int secondNumber)
        {
            try
            {
                if (secondNumber == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero !");
                }
                return firstNumber / secondNumber;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
