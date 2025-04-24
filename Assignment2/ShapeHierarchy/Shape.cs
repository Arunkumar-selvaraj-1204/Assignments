using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal abstract class Shape
    {
        public string color { get; set; }
        public abstract double CalculateArea();
        public void PrintDetails()
        {
            Console.WriteLine("It a generic shape");
        }

    }
}
