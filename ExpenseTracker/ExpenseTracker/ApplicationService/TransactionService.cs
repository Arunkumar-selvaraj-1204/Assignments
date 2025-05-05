using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.ConsoleIOHandler;
using static ExpenseTracker.Model.ApplicationEnum;
using ExpenseTracker.Model;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using ExpenseTracker.Utils;

namespace ExpenseTracker.ApplicationService
{
    public class TransactionService
    {
        private ConsoleInputHandler _consoleInputHandler;
        
        private List<Income> _listOfIncome  = InitializeListOfIncome();
        public TransactionService(ConsoleInputHandler inputHandler) {
            _consoleInputHandler = inputHandler;
        }
        public void TrackIncome()
        {
            ConsoleOutputHandler.DisplayIncomeChoice();
            int userChoice =  _consoleInputHandler.GetUserChoice();
            IncomeChoice choice = (IncomeChoice)userChoice;
            switch (choice)
            {
                case IncomeChoice.AddIncome:
                    AddIncome();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.EditIncome:
                    EditIncome();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.DeleteIncome:
                    DeleteIncome();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.ShowAllIncome:
                    ShowAllIncome();
                    break;

            }
            
        }

        public void TrackExpense()
        {
            OutputManager.DisplayExpenseChoice();
            int userChoice = _inputManager.GetUserChoice();
            ExpenseChoice choice = (ExpenseChoice)userChoice;
            switch (choice)
            {
                case ExpenseChoice.AddExpense:
                    AddExpense();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.EditIncome:
                    EditIncome();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.DeleteIncome:
                    DeleteIncome();
                    WriteToFile("IncomeList.json");
                    break;
                case IncomeChoice.ShowAllIncome:
                    ShowAllIncome();
                    break;

            }
        }

        //helper
        public void AddIncome()
        {
            Income income =_consoleInputHandler.GetIncomeDetails();
            _listOfIncome.Add(income);
            
        }
        public void AddExpense()
        {
            Expense expense = _inputManager.GetExpenseDetails();
            _listOfExpense.Add(expense);

        }
        private void ShowAllIncome()
        {
            ConsoleOutputHandler.PrintAllIncome(_listOfIncome);
        }
        private void DeleteIncome()
        {
            ShowAllIncome();
            int index = _consoleInputHandler.GetIndex("delete");
            if (index > _listOfIncome.Count())
            {
                Console.WriteLine("Invalid index entered");
                return;
            }
            _listOfIncome.RemoveAt(index);
        }

        private void EditIncome()
        {
            ShowAllIncome();
            int index = _consoleInputHandler.GetIndex("edit");
            if (index > _listOfIncome.Count())
            {
                Console.WriteLine("Invalid index entered");
                return;
            }
            Income selectedRecord = _listOfIncome[index-1];
            ConsoleOutputHandler.PrintIncomeDetails(selectedRecord);
            int userChoice = _consoleInputHandler.GetUserChoice();
            EditChoice choice = (EditChoice) userChoice;
            switch (choice)
            {
                case EditChoice.EditSource:
                    selectedRecord.Source = _consoleInputHandler.GetIncomeSource();
                    break;
                case EditChoice.EditDate:
                    selectedRecord.Date = _consoleInputHandler.GetDate();
                    break;
                case EditChoice.EditAmount:
                    selectedRecord.Amount = _consoleInputHandler.GetAmount();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            _listOfIncome[index-1] = selectedRecord;
            Console.WriteLine("Edited successfully");
        }

        private void WriteToFile(string path)
        {
            string json = JsonSerializer.Serialize(_listOfIncome, new JsonSerializerOptions { WriteIndented = true });
            FileOperations.WriteListToFile(json, path);
        }
        private static List<Income> InitializeListOfIncome()
        {
            string data = FileOperations.ReadListFromFile("IncomeList.json");
            if (data != null && data !="")
            {
                return JsonSerializer.Deserialize<List<Income>>(data);
            }
            return new List<Income>();
        }
    }
}
