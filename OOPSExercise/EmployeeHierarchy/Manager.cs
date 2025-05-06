namespace EmployeeHierarchy
{
    internal class Manager : Employee
    {

        /// <summary>
        /// Gets employee name from the user.
        /// </summary>
        public void GetName()
        {
            name = ConsoleIOHandler.GetInput("name");
        }

        /// <summary>
        /// Gets employee salary from the user.
        /// </summary>
        public void GetSalary()
        {
            salary = ConsoleIOHandler.GetSalary();
        }

        /// <summary>
        /// Calculates bonus for the manager.
        /// </summary>
        /// <returns>Bonus amount</returns>
        public override decimal CalculateBonus()
        {
            return salary * (decimal) 0.05;
        }

        /// <summary>
        /// Prints employee details in the console.
        /// </summary>
        public override void PrintDetails()
        {
            ConsoleIOHandler.PrintEmployeeDetails(name, "Manager", salary, CalculateBonus());
        }
    }
}
