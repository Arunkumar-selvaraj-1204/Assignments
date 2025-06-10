using System;
namespace SortingArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of elements in an array: ");
            int arrayLength = GetInt();
            int[] numbers = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write($"Enter {i+1} element: ");
                numbers[i] = GetInt();
            }

            Console.WriteLine("Sorted array: ");
            Array.Sort(numbers, (firstNumber, secondNumber) => firstNumber - secondNumber);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] +"\n");
            }
        }

        /// <summary>
        /// Gets int from user
        /// </summary>
        /// <returns>Returns int</returns>
        public static int GetInt()
        {
            string input = Console.ReadLine();
            int value;
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
