using System.Reflection.Emit;
using Spectre.Console;

namespace NumberFilter
{
    internal class Program
    {
        static void Main()
        {
            AnsiConsole.MarkupLine($"\n[cyan]Application to find squares of even or odd numbers in the array[/]");
            int arrayLength = AnsiConsole.Ask<int>("Enter number of elements in the array:");
            int[] numbers = GetNumbers(arrayLength);

            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a filter:")
                    .PageSize(10)
                    .AddChoices("Even numbers", "Odd numbers"));

            var filteredNumbers = FilterNumbers(numbers, choice);
            DisplayResults(filteredNumbers, $"{choice}");

            var squaredNumbers = GetSquares(filteredNumbers);
            DisplayResults(squaredNumbers, $"Squares of {choice}");
        }

        /// <summary>
        /// Reads an array of integers from the user.
        /// </summary>
        static int[] GetNumbers(int count)
        {
            var numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = AnsiConsole.Ask<int>($"Enter element {i + 1}:");
            }
            return numbers;
        }

        /// <summary>
        /// Filters even or odd numbers based on choice.
        /// </summary>
        static IEnumerable<int> FilterNumbers(IEnumerable<int> numbers, string choice)
        {
            return choice == "Even numbers"
                ? numbers.Where(x => x % 2 == 0)
                : numbers.Where(x => x % 2 != 0);
        }

        /// <summary>
        /// Calculates square of each number.
        /// </summary>
        static IEnumerable<int> GetSquares(IEnumerable<int> numbers)
        {
            return numbers.Select(x => x * x);
        }

        /// <summary>
        /// Displays a list of numbers with a label.
        /// </summary>
        static void DisplayResults(IEnumerable<int> numbers, string label)
        {
            AnsiConsole.MarkupLine($"\n[green]{label}[/]:");
            foreach (var number in numbers)
            {
                AnsiConsole.MarkupLine($"[yellow]{number}[/]");
            }
        }
    }
}
