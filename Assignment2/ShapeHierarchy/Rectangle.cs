namespace ShapeHierarchy
{
    internal class Rectangle : Shape
    {
        private double _length;
        private double _breadth;

        public void GetLength()
        {
            _length = ConsoleInputManager.GetInput("Length");
        }
        public void GetBreadth()
        {
            _breadth = ConsoleInputManager.GetInput("Breadth");
        }

        public void GetColor()
        {
            color = ConsoleInputManager.GetColor();
        }
        public override double CalculateArea()
        {
            return _length * _breadth;
        }

        public void PrintDetails()
        {
            ConsoleOutputManager.PrintShapeDetails(color, "Rectangle", CalculateArea());
        }
    }
}
