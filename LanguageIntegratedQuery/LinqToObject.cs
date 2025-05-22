using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class LinqToObject
    {
       private int[] numbers = { 45, 12, 78, 56, 89, 23, 45, 67, 12, 34, 78, 90, 23, 56, 89, 67, 12, 34, 45, 78, 90 };

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 3: THE ARRAY");
            Console.ResetColor();
            foreach (int number in numbers)
            {
                Console.Write($"{number},");
            }
            RunTasks3_1();
            RunTask3_2(124);
        }

        /// <summary>
        /// Displays second largest number in array.
        /// </summary>
        private void RunTasks3_1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 3.1: Display second largest number in array.");
            Console.ResetColor();

            int secondLargestElement = numbers.Distinct().OrderByDescending(number => number).ToArray()[1];
            Console.WriteLine($"Second largest element in the array: {secondLargestElement}");
        }

        /// <summary>
        /// Displays all unique pairs of numbers in the array that add up to a specified target
        /// </summary>
        /// <param name="targetNumber">Target number</param>
        private void RunTask3_2(int targetNumber)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\nTask 3.2: Display all unique pairs of numbers in the array that add up to a specified target. ({targetNumber}) ");
            Console.ResetColor();

            IEnumerable<(int num1, int num2)> uniqueSumPairs = numbers.Distinct().Where(number => numbers.Contains(targetNumber - number)).Select(number => (number, targetNumber - number));
            foreach (var pairs in uniqueSumPairs)
            {
                Console.WriteLine($"Number 1: {pairs.num1} - Number 2: {pairs.num2}");
            }
        }
    }
}
