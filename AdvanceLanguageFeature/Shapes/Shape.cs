using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Base class for all shapes.
    /// </summary>
    public abstract class Shape
    {
        public string Name { get; set; }
        public abstract double CalculateArea();
    }
}
