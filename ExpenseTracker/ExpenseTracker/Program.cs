using ExpenseTracker.ApplicationService;
using ExpenseTracker.ConsoleIOHandler;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleInputHandler inputHandler = new ConsoleInputHandler();
            TransactionService transactionHandler = new TransactionService(inputHandler);
            AppService app = new AppService(inputHandler, transactionHandler);
            app.DisplayMainMenu();
        }
    }
}
