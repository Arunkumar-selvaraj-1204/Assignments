namespace EmployeeHierarchy
{
    internal class Manager : Employee
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
            return salary * (decimal) 0.05;
        }

        public void PrintDetails()
        {
            ConsoleIOHandler.PrintEmployeeDetails(name, "Manager", salary, CalculateBonus());
        }
    }
}
