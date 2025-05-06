namespace ShapeHierarchy
{
    internal class ShapeGenerator
    {

        /// <summary>
        /// Creates rectangle and prints shape details.
        /// </summary>
        public void CreateRectangle()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.GetLength();
            rectangle.GetBreadth();
            rectangle.GetColor();
            rectangle.PrintDetails();
        }

        /// <summary>
        /// Creates circle and prints shape details.
        /// </summary>
        public void CreateCircle()
        {
            Circle circle = new Circle();
            circle.GetRadius();
            circle.GetColor();
            circle.PrintDetails();
        }
    }
}
