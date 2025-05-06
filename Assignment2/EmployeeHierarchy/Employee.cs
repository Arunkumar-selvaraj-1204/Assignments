namespace EmployeeHierarchy
{
    internal abstract class Employee
    {
        public string name { get; set; }
        public decimal salary { get; set; }
        public abstract decimal CalculateBonus();
        public void PrintDetails()
        {
            Console.WriteLine("It is generic employee");
        }

    }
}
