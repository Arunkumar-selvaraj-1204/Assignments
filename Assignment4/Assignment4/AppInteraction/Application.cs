using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.IOManager;
using static ExpenseTracker.Model.ApplicationEnum;

namespace ExpenseTracker.AppInteraction
{
    internal class Application
    {
        private InputManager _inputManager;
        private MoneyManager _moneyManager;

        public Application(InputManager inputManager, MoneyManager moneyManager)
        {
            _moneyManager = moneyManager;
            _inputManager = inputManager;
        }
        public void DisplayMainMenu()
        {
            bool isExit = false;
            while (!isExit)
            {
                OutputManager.PrintMainMenu();
                int userChoice = _inputManager.GetUserChoice();
                MainMenu choice = (MainMenu)userChoice;
                switch (choice)
                {
                    case MainMenu.TrackIncome:
                        _moneyManager.TrackIncome();
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
