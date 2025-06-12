using System;
using Spectre.Console;
namespace Shapes
{
    internal class Program
    {
        static void Main()
        {
            List<Shape> shapes = new();
            bool running = true;

            while (running)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Choose an option:[/]")
                        .AddChoices("Add Circle", "Add Rectangle", "Add Triangle", "Add Null Shape", "View All Shapes", "Exit"));

                switch (option)
                {
                    case "Add Circle":
                        shapes.Add(CreateCircle());
                        break;
                    case "Add Rectangle":
                        shapes.Add(CreateRectangle());
                        break;
                    case "Add Triangle":
                        shapes.Add(CreateTriangle());
                        break;
                    case "Add Null Shape":
                        shapes.Add(null); // Adds a null entry to demonstrate pattern match
                        break;
                    case "View All Shapes":
                        DisplayAllShapes(shapes);
                        break;
                    case "Exit":
                        running = false;
                        break;
                }
                AnsiConsole.MarkupLine("[grey]Press Enter to continue...[/]");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static Circle CreateCircle()
        {
            string name = AnsiConsole.Ask<string>("Enter the name of the Circle:");
            double radius = AnsiConsole.Ask<double>("Enter the radius:");
            return new Circle(name, radius);
        }

        static Rectangle CreateRectangle()
        {
            string name = AnsiConsole.Ask<string>("Enter the name of the Rectangle:");
            double width = AnsiConsole.Ask<double>("Enter the width:");
            double height = AnsiConsole.Ask<double>("Enter the height:");
            return new Rectangle(name, width, height);
        }

        static Triangle CreateTriangle()
        {
            string name = AnsiConsole.Ask<string>("Enter the name of the Triangle:");
            double baseLength = AnsiConsole.Ask<double>("Enter the base length:");
            double height = AnsiConsole.Ask<double>("Enter the height:");
            return new Triangle(name, baseLength, height);
        }

        static void DisplayAllShapes(IEnumerable<Shape> shapes)
        {
            AnsiConsole.MarkupLine("[yellow]--- Shape Details ---[/]");
            foreach (var shape in shapes)
            {
                DisplayShapeDetails(shape);
                Console.WriteLine();
            }
        }

        static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    AnsiConsole.MarkupLine($"[blue]Shape:[/] {c.Name} (Circle)");
                    AnsiConsole.MarkupLine($"Radius: {c.Radius}");
                    AnsiConsole.MarkupLine($"Area: [green]{c.CalculateArea():F2}[/]");
                    break;
                case Rectangle r:
                    AnsiConsole.MarkupLine($"[blue]Shape:[/] {r.Name} (Rectangle)");
                    AnsiConsole.MarkupLine($"Width: {r.Width}, Height: {r.Height}");
                    AnsiConsole.MarkupLine($"Area: [green]{r.CalculateArea():F2}[/]");
                    break;
                case Triangle t:
                    AnsiConsole.MarkupLine($"[blue]Shape:[/] {t.Name} (Triangle)");
                    AnsiConsole.MarkupLine($"Base: {t.BaseLength}, Height: {t.Height}");
                    AnsiConsole.MarkupLine($"Area: [green]{t.CalculateArea():F2}[/]");
                    break;
                case null:
                    AnsiConsole.MarkupLine("[red]Shape is null.[/]");
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Unknown shape type.[/]");
                    break;
            }
        }
    }
}
