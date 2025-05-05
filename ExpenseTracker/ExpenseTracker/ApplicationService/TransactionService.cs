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
        private List<Expense> _listOfExpense = InitializeListOfExpense();
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
                    WriteToFile("ExpenseList.json");
                    break;
                case ExpenseChoice.EditExpense:
                    EditExpense();
                    WriteToFile("ExpenseList.json");
                    break;
                case ExpenseChoice.DeleteExpense:
                    DeleteExpense();
                    WriteToFile("ExpenseList.json");
                    break;
                case ExpenseChoice.ShowAllExpense:
                    ShowAllExpense();
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

        public void ShowAllExpense()
        {
            OutputManager.PrintAllExpense(_listOfExpense);
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
            _listOfIncome.RemoveAt(index -1);
        }

        public void DeleteExpense()
        {
            int index = _inputManager.GetIndex("delete");
            if (index > _listOfExpense.Count())
            {
                Console.WriteLine("Invalid index entered");
                return;
            }
            _listOfExpense.RemoveAt(index - 1);
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
                case EditChoice.EditSourceOrCategory:
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

        private void EditExpense()
        {
            ShowAllExpense();
            int index = _inputManager.GetIndex("edit");
            if (index > _listOfIncome.Count())
            {
                Console.WriteLine("Invalid index entered");
                return;
            }
            Expense selectedRecord = _listOfExpense[index - 1];
            OutputManager.PrintExpenseDetails(selectedRecord);
            int userChoice = _inputManager.GetUserChoice();
            EditChoice choice = (EditChoice)userChoice;
            switch (choice)
            {
                case EditChoice.EditSourceOrCategory:
                    selectedRecord.Category = _inputManager.GetCategory();
                    break;
                case EditChoice.EditDate:
                    selectedRecord.Date = _inputManager.GetDate();
                    break;
                case EditChoice.EditAmount:
                    selectedRecord.Amount = _inputManager.GetAmount();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            _listOfExpense[index - 1] = selectedRecord;
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
        private static List<Expense> InitializeListOfExpense()
        {
            string data = FileOperations.ReadListFromFile("ExpenseList.json");
            if (data != null && data != "")
            {
                return JsonSerializer.Deserialize<List<Expense>>(data);
            }
            return new List<Expense>();
        }
    }
}
