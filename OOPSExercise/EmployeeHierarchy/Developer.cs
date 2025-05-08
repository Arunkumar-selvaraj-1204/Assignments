namespace EmployeeHierarchy
{
    internal class Developer : Employee
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
        /// Calculates bonus for the developer.
        /// </summary>
        /// <returns>Bonus amount</returns>
        public override decimal CalculateBonus()
        {
            decimal bonusPercentage = ConsoleIOHandler.GetBonusPercentage();
            return salary * bonusPercentage;
        }

        /// <summary>
        /// Prints employee details in the console.
        /// </summary>
        public override void PrintDetails()
        {
            ConsoleIOHandler.PrintEmployeeDetails(name, "Developer", salary, CalculateBonus());
        }
    }
}
