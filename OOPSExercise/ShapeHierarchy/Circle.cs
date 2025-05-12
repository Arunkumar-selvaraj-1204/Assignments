namespace ShapeHierarchy
{
    internal class Circle: Shape
    {
        private double _radius;


        /// <summary>
        /// Gets radius of the circle from the user.
        /// </summary>
        public void GetRadius()
        {
            _radius = ConsoleInputHandler.GetInput("Radius");
        }

        /// <summary>
        /// Gets color of the shape from the user.
        /// </summary>
        public void GetColor()
        {
            color = ConsoleInputHandler.GetColor();
        }

        /// <summary>
        /// Calculates area of the circle.
        /// </summary>
        /// <returns>Area of the circle</returns>
        public override double CalculateArea()
        {
            return Math.PI*_radius*_radius;
        }

        /// <summary>
        /// Prints shape details in the console.
        /// </summary>
        public override void PrintDetails()
        {
            ConsoleOutputHandler.PrintShapeDetails(color, "Circle", CalculateArea());
        }
    }
}
