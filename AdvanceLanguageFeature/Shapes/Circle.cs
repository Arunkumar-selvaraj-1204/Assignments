using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Represents a circle with a radius.
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;
        }
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
