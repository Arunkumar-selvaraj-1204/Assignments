using System.Threading.Tasks;
using Spectre.Console;
using CollectionAndGenerics.Task1;
using CollectionAndGenerics.Task2;
using CollectionAndGenerics.Task3;
using CollectionAndGenerics.Task4;
using CollectionAndGenerics.Task5;
using CollectionAndGenerics.Task6;
namespace CollectionAndGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            string[] menuOptions = new[]
            {
            "1. BookStore Operations",
            "2. String Reverse Using Stacks",
            "3. Queue Organizer",
            "4. Student Grade System (Dictionary)",
            "5. Generic Collections",
            "6. Understanding Collections (Task 6)",
            "Exit"
        };

            while (isRunning)
            {
                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an operation to execute:")
                        .PageSize(10)
                        .AddChoices(menuOptions));

                switch (choice)
                {
                    case "1. BookStore Operations":
                        var bookStore = new BookStore();
                        bookStore.ExecuteListOperations();
                        break;

                    case "2. String Reverse Using Stacks":
                        var stringReverse = new StringReverseUsingStacks();
                        stringReverse.ExecuteStackOperations();
                        break;

                    case "3. Queue Organizer":
                        var queueOrganizer = new QueueOrganizer();
                        queueOrganizer.ExecuteQueueOperations();
                        break;

                    case "4. Student Grade System (Dictionary)":
                        var gradeSystem = new StudentGradeSystem();
                        gradeSystem.ExecuteDictionaryOperations();
                        break;

                    case "5. Generic Collections":
                        var genericCollections = new GenericCollections();
                        genericCollections.ExecuteGenericOperations();
                        break;

                    case "6. Understanding Collections (Task 6)":
                        var understandingCollections = new UnderstandingCollections();
                        understandingCollections.ExecuteTask6();
                        break;

                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Exiting application...[/]");
                        isRunning = false;
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid choice.[/]");
                        break;
                }

                if (isRunning)
                {
                    AnsiConsole.MarkupLine("\n[blue]Press any key to return to the menu...[/]");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}
