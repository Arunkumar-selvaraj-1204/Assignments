using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    internal class Circle: Shape
    {
        private double _radius;

        public void GetRadius()
        {
            _radius = InputManager.GetInput("Radius");
        }
        public void GetColor()
        {
            color = InputManager.GetColor();
        }
        public override double CalculateArea()
        {
            return Math.PI*_radius*_radius;
        }

        public void PrintDetails()
        {
            OutputManager.PrintShapeDetails(color, "Circle", CalculateArea());
        }
    }
}
