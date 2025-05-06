namespace ShapeHierarchy
{
    internal abstract class Shape
    {
        public string color { get; set; }
        public abstract double CalculateArea();

        /// <summary>
        /// Prints shape details and it will get override by child classes.
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine("It a generic shape");
        }

    }
}
