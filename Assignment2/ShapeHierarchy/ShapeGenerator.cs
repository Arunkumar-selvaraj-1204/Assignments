namespace ShapeHierarchy
{
    internal class ShapeGenerator
    {
        public void CreateRectangle()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.GetLength();
            rectangle.GetBreadth();
            rectangle.GetColor();
            rectangle.PrintDetails();
        }

        public void CreateCircle()
        {
            Circle circle = new Circle();
            circle.GetRadius();
            circle.GetColor();
            circle.PrintDetails();
        }
    }
}
