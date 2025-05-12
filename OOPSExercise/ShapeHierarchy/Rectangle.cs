namespace ShapeHierarchy
{
    internal class Rectangle : Shape
    {
        private double _length;
        private double _breadth;

        /// <summary>
        /// Gets length of the rectangle.
        /// </summary>
        public void GetLength()
        {
            _length = ConsoleInputHandler.GetInput("Length");
        }

        //Gets breadth of the rectangle.
        public void GetBreadth()
        {
            _breadth = ConsoleInputHandler.GetInput("Breadth");
        }

        /// <summary>
        /// Gets color of the shape.
        /// </summary>
        public void GetColor()
        {
            color = ConsoleInputHandler.GetColor();
        }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns>Area of the rectangle.</returns>
        public override double CalculateArea()
        {
            return _length * _breadth;
        }


        /// <summary>
        /// Prints shape details in the console.
        /// </summary>
        public override void PrintDetails()
        {
            ConsoleOutputHandler.PrintShapeDetails(color, "Rectangle", CalculateArea());
        }
    }
}
