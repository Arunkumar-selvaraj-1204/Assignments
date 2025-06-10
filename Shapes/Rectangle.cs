using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Represents a rectangle with width and height.
    /// </summary>
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(string name, double width, double height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
        public override double CalculateArea() => Width * Height;
    }

}
