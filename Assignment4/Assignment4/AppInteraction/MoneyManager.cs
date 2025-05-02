using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.IOManager;
using static ExpenseTracker.Model.ApplicationEnum;
using ExpenseTracker.Model;
using System.Runtime.CompilerServices;

namespace ExpenseTracker.AppInteraction
{
    public class MoneyManager
    {
        private InputManager _inputManager;
        private List<Income> _listOfIncome = new List<Income>();
        private List<Expense> _listOfExpense = new List<Expense>();
        public MoneyManager(InputManager manager) {
            _inputManager = manager;
        }
        public void TrackIncome()
        {
            OutputManager.DisplayIncomeChoice();
            int userChoice =  _inputManager.GetUserChoice();
            IncomeChoice choice = (IncomeChoice)userChoice;
            switch (choice)
            {
                case IncomeChoice.AddIncome:
                    AddIncome();
                    break;
                case IncomeChoice.DeleteIncome:
                    DeleteIncome();
                    break;
                case IncomeChoice.ShowAllIncome:
                    ShowAllIncome();
                    break;

            }
            
        }


        //helper
        public void AddIncome()
        {
            Income income =_inputManager.GetIncomeDetails();
            _listOfIncome.Add(income);
        }
        private void ShowAllIncome()
        {
            OutputManager.PrintAllIncome(_listOfIncome);
        }
        private void DeleteIncome()
        {
            ShowAllIncome();
            int index = _inputManager.GetIndex("delete");
            _listOfIncome.RemoveAt(index);
        }
    }
}
