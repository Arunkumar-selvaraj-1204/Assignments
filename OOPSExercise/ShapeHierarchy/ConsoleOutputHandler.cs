namespace ShapeHierarchy
{
    internal class ConsoleOutputHandler
    {

        /// <summary>
        /// Prints shape details in the console.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        /// <param name="shapeType">Type of the shape</param>
        /// <param name="area">Area of the shape</param>
       public static void PrintShapeDetails(string color, string shapeType, double area)
        {
            Console.WriteLine($"Color: {color}\nShape type: {shapeType}\nArea: {area}");
            Console.WriteLine("\n========================\n");
        }
    }
}
