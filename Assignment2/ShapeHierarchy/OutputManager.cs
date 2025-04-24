using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal class OutputManager
    {
       public static void PrintShapeDetails(string color, string shapeType, double area)
        {
            Console.WriteLine($"Color: {color}\nShape type: {shapeType}\nArea: {area}");
            Console.WriteLine("\n========================\n");
        }
    }
}
