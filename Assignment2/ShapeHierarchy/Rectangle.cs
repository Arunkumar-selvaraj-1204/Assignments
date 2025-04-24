using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal class Rectangle : Shape
    {
        private double _length;
        private double _breadth;

        public void GetLength()
        {
            _length = InputManager.GetInput("Length");
        }
        public void GetBreadth()
        {
            _breadth = InputManager.GetInput("Breadth");
        }

        public void GetColor()
        {
            color = InputManager.GetColor();
        }
        public override double CalculateArea()
        {
            return _length * _breadth;
        }

        public void PrintDetails()
        {
            OutputManager.PrintShapeDetails(color, "Rectangle", CalculateArea());
        }
    }
}
