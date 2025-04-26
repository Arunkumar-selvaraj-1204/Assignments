using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.IOManager;
using InventoryManager.Model;
using static InventoryManager.Model.ApplicationEnums;

namespace InventoryManager.ApplicationManager
{
    internal class AppInteraction
    {
        bool isExit = false;
        InventoryManager inventoryManager = new InventoryManager();
        public void DisplayInitialMenu()
        {
            OutputManager.PrintInitialMenu();
            while (!isExit)
            {
                int userChoice = InputManager.GetUserChoice();
                MainMenuChoices mainMenuChoice = (MainMenuChoices)userChoice;
                MakeIntialChoice(mainMenuChoice);
            }
        }

        public void MakeIntialChoice(MainMenuChoices choice)
        {
            
                switch (choice)
                {
                    case MainMenuChoices.addProduct:
                        Console.Clear();
                        inventoryManager.AddProduct();
                        break;
                    case MainMenuChoices.viewProduct:
                        Console.Clear();
                        inventoryManager.ViewAllProducts();
                        break;
                    case MainMenuChoices.searchProduct:
                        Console.Clear();
                        inventoryManager.SearchProduct();
                        break;
                    case MainMenuChoices.editProduct:
                        break;
                    case MainMenuChoices.deleteProduct:
                        //delete
                        break;
                    case MainMenuChoices.exit:
                        isExit = true;
                        break;
                    default:
                        OutputManager.PrintInvalidOption("Choice should be between 1 - 6");
                        break;
                }
            
        }
    }
}
