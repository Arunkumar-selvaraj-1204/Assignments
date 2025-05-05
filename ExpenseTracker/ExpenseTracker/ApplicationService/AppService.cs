using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.ConsoleIOHandler;
using static ExpenseTracker.Model.ApplicationEnum;

namespace ExpenseTracker.ApplicationService
{
    internal class AppService
    {
        private ConsoleInputHandler _consoleInputHandler;
        private TransactionService _transactionHandler;

        public AppService(ConsoleInputHandler inputHandler, TransactionService transactionHandler)
        {
            _transactionHandler = transactionHandler;
            _consoleInputHandler = inputHandler;
        }
        public void DisplayMainMenu()
        {
            bool isExit = false;
            while (!isExit)
            {
                ConsoleOutputHandler.PrintMainMenu();
                int userChoice = _consoleInputHandler.GetUserChoice();
                MainMenu choice = (MainMenu)userChoice;
                switch (choice)
                {
                    case MainMenu.TrackIncome:
                        Console.Clear();
                        _transactionHandler.TrackIncome();  
                        break;
                    case MainMenu.TrackExpense:
                        Console.Clear();
                        _moneyManager.TrackExpense();
                        break;
                    case MainMenu.FinancialSummary:
                        _moneyManager.ShowFinancialSummary();
                        break;
                    case MainMenu.Exit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            }

        }
    }
}
