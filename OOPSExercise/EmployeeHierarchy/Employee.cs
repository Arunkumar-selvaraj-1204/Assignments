namespace EmployeeHierarchy
{
    internal abstract class Employee
    {
        public string name { get; set; }
        public decimal salary { get; set; }
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Prints message in the console and this method will be over ride by child classes.
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine("It is generic employee");
        }

    }
}
