using Spectre.Console;

namespace NumberFilter
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
                Console.Write($"Enter {i + 1} element: ");
                numbers[i] = GetInt();
            }

            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a filter:")
                .PageSize(10)
                .AddChoices(new[] {
                    "Even numbers",
                    "Odd numbers"
                }));
            var filteredNumbers = FilterNumbers(numbers, choice);
            Console.WriteLine($"{choice}:");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Square of {choice}");
            var squaredNumbers = GetSquare(filteredNumbers);
            foreach (var number in squaredNumbers)
            {
                Console.WriteLine(number);
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

        private static IEnumerable<int> FilterNumbers(int[] numbers, string choice)
        {
            IEnumerable<int> filteredNumbers;
            if (choice == "Even numbers")
            {
                filteredNumbers = numbers.Where(x => x % 2 == 0);
            }
            else
            {
                filteredNumbers = numbers.Where(x => x % 2 != 0);
            }
            return filteredNumbers;
        }

        private static IEnumerable<int> GetSquare(IEnumerable<int> numbers)
        {
            return numbers.Select(x => { return x * x; });
        }
    }
}
