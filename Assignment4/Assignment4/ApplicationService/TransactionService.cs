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
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ConsoleOutputHandler.DisplayIncomeChoice();
                int userChoice = _consoleInputHandler.GetUserChoice();
                IncomeChoice choice = (IncomeChoice)userChoice;
                switch (choice)
                {
                    case IncomeChoice.AddIncome:
                        AddIncome();
                        WriteToFile("IncomeList.json", _listOfIncome);
                        break;
                    case IncomeChoice.EditIncome:
                        EditIncome();
                        WriteToFile("IncomeList.json", _listOfIncome);
                        break;
                    case IncomeChoice.DeleteIncome:
                        DeleteIncome();
                        WriteToFile("IncomeList.json", _listOfIncome);
                        break;
                    case IncomeChoice.ShowAllIncome:
                        ShowAllIncome();
                        Utilities.PressAnyKey();
                        break;
                    case IncomeChoice.MainMenu:
                        isExit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            
        }

        public void TrackExpense()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                OutputManager.DisplayExpenseChoice();
                int userChoice = _inputManager.GetUserChoice();
                ExpenseChoice choice = (ExpenseChoice)userChoice;
                switch (choice)
                {
                    case ExpenseChoice.AddExpense:
                        AddExpense();
                        WriteToFile("ExpenseList.json", _listOfExpense);
                        break;
                    case ExpenseChoice.EditExpense:
                        EditExpense();
                        WriteToFile("ExpenseList.json", _listOfExpense);
                        break;
                    case ExpenseChoice.DeleteExpense:
                        DeleteExpense();
                        WriteToFile("ExpenseList.json", _listOfExpense);
                        break;
                    case ExpenseChoice.ShowAllExpense:
                        ShowAllExpense();
                        Utilities.PressAnyKey();
                        break;
                    case ExpenseChoice.MainMenu:
                        isExit = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
        }

        //helper
        public void AddIncome()
        {
            Income income =_consoleInputHandler.GetIncomeDetails();
            _listOfIncome.Add(income);
            Utilities.PrintSuccessMessage("Added");
            
        }
        public void AddExpense()
        {
            Expense expense = _inputManager.GetExpenseDetails();
            _listOfExpense.Add(expense);
            Utilities.PrintSuccessMessage("Added");
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
                Utilities.PressAnyKey();
                return;
            }
            _listOfIncome.RemoveAt(index -1);
            Utilities.PrintSuccessMessage("Deleted");
        }

        public void DeleteExpense()
        {
            int index = _inputManager.GetIndex("delete");
            if (index > _listOfExpense.Count())
            {
                Console.WriteLine("Invalid index entered");
                Utilities.PressAnyKey();
                return;
            }
            _listOfExpense.RemoveAt(index - 1);
            Utilities.PrintSuccessMessage("Deleted");
        }

        private void EditIncome()
        {
            ShowAllIncome();
            int index = _consoleInputHandler.GetIndex("edit");
            if (index > _listOfIncome.Count())
            {
                Console.WriteLine("Invalid index entered");
                Utilities.PressAnyKey();
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
            Utilities.PrintSuccessMessage("Edited");
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
            Utilities.PrintSuccessMessage("Edited");
        }
        private void WriteToFile<T>(string path, List<T> transationList)
        {
            string json = JsonSerializer.Serialize(transationList, new JsonSerializerOptions { WriteIndented = true });
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
