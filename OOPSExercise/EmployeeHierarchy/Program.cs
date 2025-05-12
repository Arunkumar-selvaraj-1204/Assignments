namespace EmployeeHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BonusCalculator calculator = new BonusCalculator();
            Console.WriteLine("Select your role");
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = ConsoleIOHandler.GetChoice();
                switch (userChoice)
                {
                    case 1:
                        calculator.DisplayManagerBonus();
                        break;
                    case 2:
                        calculator.DisplayDeveloperBonus();
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
        }
    }
}
