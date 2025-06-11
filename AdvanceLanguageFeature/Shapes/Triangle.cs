using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Represents a triangle with base and height.
    /// </summary>
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }
        public Triangle(string name, double baseLength, double height)
        {
            Name = name;
            BaseLength = baseLength;
            Height = height;
        }
        public override double CalculateArea() => 0.5 * BaseLength * Height;
    }
}
