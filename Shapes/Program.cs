namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
        {
            new Circle("Circle One", 3.5),
            new Rectangle("Rectangle One", 5, 7),
            new Triangle("Triangle One", 4, 6),
            null // To demonstrate null pattern
        };

            foreach (var shape in shapes)
            {
                DisplayShapeDetails(shape);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Uses pattern matching to print details and area of a shape.
        /// </summary>
        /// <param name="shape">The shape object.</param>
        static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine($"Shape: {c.Name} (Circle)");
                    Console.WriteLine($"Radius: {c.Radius}");
                    Console.WriteLine($"Area: {c.CalculateArea():F2}");
                    break;
                case Rectangle r:
                    Console.WriteLine($"Shape: {r.Name} (Rectangle)");
                    Console.WriteLine($"Width: {r.Width}, Height: {r.Height}");
                    Console.WriteLine($"Area: {r.CalculateArea():F2}");
                    break;
                case Triangle t:
                    Console.WriteLine($"Shape: {t.Name} (Triangle)");
                    Console.WriteLine($"Base: {t.BaseLength}, Height: {t.Height}");
                    Console.WriteLine($"Area: {t.CalculateArea():F2}");
                    break;
                case null:
                    Console.WriteLine("Shape is null.");
                    break;
                default:
                    Console.WriteLine("Unknown shape type.");
                    break;
            }
        }
    }
}
