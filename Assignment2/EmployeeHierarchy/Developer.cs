namespace EmployeeHierarchy
{
    internal class Developer : Employee
    {
        public void GetName()
        {
            name = ConsoleIOHandler.GetInput("name");
        }
        public void GetSalary()
        {
            salary = ConsoleIOHandler.GetSalary();
        }

        public override decimal CalculateBonus()
        {
            return salary * (decimal)0.02;
        }

        public void PrintDetails()
        {
            ConsoleIOHandler.PrintEmployeeDetails(name, "Developer", salary, CalculateBonus());
        }
    }
}
