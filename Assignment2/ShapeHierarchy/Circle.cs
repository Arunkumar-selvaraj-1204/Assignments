namespace ShapeHierarchy
{
    internal class Circle: Shape
    {
        private double _radius;

        public void GetRadius()
        {
            _radius = ConsoleInputManager.GetInput("Radius");
        }
        public void GetColor()
        {
            color = ConsoleInputManager.GetColor();
        }
        public override double CalculateArea()
        {
            return Math.PI*_radius*_radius;
        }

        public void PrintDetails()
        {
            ConsoleOutputManager.PrintShapeDetails(color, "Circle", CalculateArea());
        }
    }
}
