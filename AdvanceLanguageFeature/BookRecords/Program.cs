using System;
using Spectre.Console;
namespace BookRecords
{
    public record Book(string Title, string Author, string ISBN);

    class Program
    {
        static void Main()
        {
            bool running = true;

            while (running)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]What would you like to do?[/]")
                        .AddChoices(new[]
                        {
                        "Enter books and display them",
                        "Demonstrate value equality",
                        "Demonstrate immutability",
                        "Demonstrate 'with' mutation",
                        "Exit"
                        }));

                switch (choice)
                {
                    case "Enter books and display them":
                        EnterAndDisplayBooks();
                        break;

                    case "Demonstrate value equality":
                        DemonstrateEquality();
                        break;

                    case "Demonstrate immutability":
                        DemonstrateImmutability();
                        break;

                    case "Demonstrate 'with' mutation":
                        DemonstrateWithMutation();
                        break;

                    case "Exit":
                        AnsiConsole.MarkupLine("[green]Goodbye![/]");
                        running = false;
                        break;
                }

                if (running)
                {
                    AnsiConsole.MarkupLine("\n[gray]Press Enter to continue...[/]");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void EnterAndDisplayBooks()
        {
            var books = new Book[3];
            AnsiConsole.MarkupLine($"\n[blue]Enter details of three books to display using records[/]");
            for (int i = 0; i < books.Length; i++)
            {
                AnsiConsole.MarkupLine($"\n[blue]Enter details for Book {i + 1}[/]");

                string title = AnsiConsole.Ask<string>("Title:");
                string author = AnsiConsole.Ask<string>("Author:");
                string isbn = AnsiConsole.Ask<string>("ISBN:");

                books[i] = new Book(title, author, isbn);
            }

            AnsiConsole.MarkupLine("\n[green]--- Book Details ---[/]");
            foreach (var book in books)
            {
                DisplayBook(book);
            }
        }

        static void DisplayBook(Book book)
        {
            AnsiConsole.MarkupLine($"[cyan]Title:[/] {book.Title}");
            AnsiConsole.MarkupLine($"[cyan]Author:[/] {book.Author}");
            AnsiConsole.MarkupLine($"[cyan]ISBN:[/] {book.ISBN}\n");
        }

        static void DemonstrateEquality()
        {
            var bookA = new Book("C# in Depth", "Jon Skeet", "9781617294532");
            var bookB = new Book("C# in Depth", "Jon Skeet", "9781617294532");

            AnsiConsole.MarkupLine("\n[green]--- Value Equality Demo ---[/]");
            DisplayBook(bookA);
            DisplayBook(bookB);

            Console.WriteLine($"BookA == BookB: {bookA == bookB}");
        }

        static void DemonstrateImmutability()
        {
            var book = new Book("Immutable Book", "Alice", "1234567890");
            DisplayBook(book);
            AnsiConsole.MarkupLine("[red]You can't modify a record's property after creation![/]");
        }

        static void DemonstrateWithMutation()
        {
            var bookA = new Book("C# in Depth", "Jon Skeet", "9781617294532");

            AnsiConsole.MarkupLine("[blue]Enter a new title for bookA:[/]");
            string newTitle = Console.ReadLine();

            var updatedBookA = bookA with { Title = newTitle };

            AnsiConsole.MarkupLine("\n[green]--- Non-destructive Mutation Demo ---[/]");
            AnsiConsole.MarkupLine("[yellow]Original:[/]");
            DisplayBook(bookA);

            AnsiConsole.MarkupLine("[yellow]After 'with':[/]");
            DisplayBook(updatedBookA);
        }
    }
}
