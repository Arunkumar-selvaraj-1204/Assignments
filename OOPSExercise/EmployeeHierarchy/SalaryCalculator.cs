namespace EmployeeHierarchy
{
    internal class SalaryCalculator
    {
        /// <summary>
        /// Gets manager details and prints with their bonus.
        /// </summary>
        public void DisplayManagerBonus()
        {
            Manager manager = new Manager();
            manager.GetName();
            manager.GetSalary();
            manager.PrintDetails();
        }

        /// <summary>
        /// Gets developer details and prints with their bonus.
        /// </summary>
        public void DisplayDeveloperBonus()
        {
            Developer developer = new Developer();
            developer.GetName();
            developer.GetSalary();
            developer.PrintDetails();

        }
    }
}
