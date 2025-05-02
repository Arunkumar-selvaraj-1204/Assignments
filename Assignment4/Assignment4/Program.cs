using ExpenseTracker.AppInteraction;
using ExpenseTracker.IOManager;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            MoneyManager moneyManager = new MoneyManager(inputManager);
            Application app = new Application(inputManager, moneyManager);
            app.DisplayMainMenu();
        }
    }
}
