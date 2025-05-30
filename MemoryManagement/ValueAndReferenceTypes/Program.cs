using System;

namespace ValueAndReferenceTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = 4;
            Person person = new Person();
            person.Name = "Arun";
            person.Age = 21;

            Console.WriteLine("-------- Memory Management in C# --------");
            Console.WriteLine("-------- Value and Reference types --------");

            // Print the value of integer and object member before function call
            Console.WriteLine($"Value of value type before function call is {number}." +
                $"\nValue of reference type before function call is {person.Age}.");

            IncrementByOne(number, person);

            // Print the value of integer and object member after function call
            Console.WriteLine($"\nValue of value type after function call is {number}." +
                $"\nValue of reference type after function call is {person.Age}.");

            Console.WriteLine("\n-------- Working with integers --------");
            // Call the function dealing with numbers
            Console.WriteLine($"Sum of given integers is {SumOfIntegers()}."); 

            Console.WriteLine("\n-------- Working with array of integers --------");
            // Call the function dealing with an array of number
            Console.WriteLine($"Sum of array elements is {SumOfArrayElements()}.");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Function to increment the number and person's age by one
        /// </summary>
        /// <param name="number"> Represents the integer number </param>
        /// <param name="person"> Represents the person object </param>
        public static void IncrementByOne(int number, Person person)
        {
            number++;
            Console.WriteLine($"\nInside the function, the value of value type is {number}.");
            person.Age++;
        }

        /// <summary>
        /// Method to calculate the sum of entered numbers by accessing the value type integers
        /// </summary>
        public static int SumOfIntegers()
        {
            Console.Write("Enter the count of numbers: ");
            int countOfNumbers = GetInteger();
            return PerformIntSum(countOfNumbers);  
        }

        /// <summary>
        /// Calculates sum
        /// </summary>
        /// <param name="countOfNumbers">count of numbers</param>
        /// <returns>sum of the numbers</returns>
        public static int PerformIntSum(int countOfNumbers)
        {
            int sum = 0;
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.Write("Enter the number: ");
                sum += GetInteger();
            }
            return sum;
        }

        /// <summary>
        /// Method to calculate the sum of entered numbers by accessing the reference type array of integers
        /// </summary>
        public static int SumOfArrayElements()
        {
            Console.Write("Enter the size of the array: ");
            int arrayLength = GetInteger();
            int[] arrayOfNumbers = new int[arrayLength];
            return PerformArraySum(arrayLength, arrayOfNumbers);
        }

        /// <summary>
        /// Calculates sum of array elements
        /// </summary>
        /// <param name="arrayLength">Length of the array</param>
        /// <param name="arrayOfNumbers">Array of numbers</param>
        /// <returns>Sum of array elements</returns>
        public static int PerformArraySum(int arrayLength, int[] arrayOfNumbers)
        {
            int sum = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Enter the number: ");
                arrayOfNumbers[i] = GetInteger();
                sum += arrayOfNumbers[i];
            }

            return sum;
        }

        /// <summary>
        /// Method to get valid integer input from the user
        /// </summary>
        /// <returns> Returns the valid parsed integer </returns>
        public static int GetInteger()
        {
            string input = Console.ReadLine();
            int validInteger;
            while (!int.TryParse(input, out validInteger))
            {
                Console.Write("Enter valid number: ");
                input = Console.ReadLine();
            }
            return validInteger;
        }
    }
}