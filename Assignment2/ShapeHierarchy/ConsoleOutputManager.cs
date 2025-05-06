namespace ShapeHierarchy
{
    internal class ConsoleOutputManager
    {
       public static void PrintShapeDetails(string color, string shapeType, double area)
        {
            Console.WriteLine($"Color: {color}\nShape type: {shapeType}\nArea: {area}");
            Console.WriteLine("\n========================\n");
        }
    }
}
