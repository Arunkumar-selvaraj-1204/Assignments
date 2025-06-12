using Spectre.Console;
using System;

namespace SortingArray
{
    internal class Program
    {
        static void Main()
        {
            AnsiConsole.MarkupLine("[bold yellow]--- Sorting Array ---[/]");

            int[] numbers = GetArrayFromUser();
            Array.Sort(numbers);

            DisplaySortedArray(numbers);

            AnsiConsole.MarkupLine("[bold green]Sorting complete![/]");
        }

        /// <summary>
        /// Prompts the user to enter an array of integers.
        /// </summary>
        private static int[] GetArrayFromUser()
        {
            int length = AnsiConsole.Ask<int>("[green]Enter the number of elements[/]:");

            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = AnsiConsole.Ask<int>($"[blue]Enter element {i + 1}[/]:");
            }
            return array;
        }

        /// <summary>
        /// Displays the sorted array.
        /// </summary>
        private static void DisplaySortedArray(int[] array)
        {
            AnsiConsole.MarkupLine("\n[bold cyan]Sorted Array:[/]");
            foreach (var num in array)
            {
                AnsiConsole.MarkupLine($"[green]{num}[/]");
            }
        }
    }
}
