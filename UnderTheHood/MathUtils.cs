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
            add(FirstNumber, SecondNumber);
            Subtract(FirstNumber, SecondNumber);
            Multiply(FirstNumber, SecondNumber);
            Divide(FirstNumber, SecondNumber);
        }

        /// <summary>
        /// add two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private void add(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"addition of {firstNumber} and {secondNumber} is {firstNumber + secondNumber}");
        }

        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private void Subtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"Subtraction of {firstNumber} and {secondNumber} is {firstNumber - secondNumber}");
        }

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private void Multiply(int firstNumber, int secondNumber)
        {
            Console.WriteLine($"Multiplication of {firstNumber} and {secondNumber} is {firstNumber * secondNumber}");
        }

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        private void Divide(int firstNumber, int secondNumber)
        {
            try
            {
                if (secondNumber == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero !");
                }
                Console.WriteLine($"Division of {firstNumber} and {secondNumber} is {firstNumber / secondNumber}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
