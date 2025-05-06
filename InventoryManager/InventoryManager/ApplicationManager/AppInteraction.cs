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
        InventoryManager inventoryManager = new InventoryManager(new List<Product>());
        InputManager inputManager = new InputManager();

        /// <summary>
        /// Displays the initial menu and continuously processes user choices until the user decides to exit.
        /// </summary>
        public void DisplayInitialMenu()
        {
            OutputManager.PrintInitialMenu();
            while (!isExit)
            {
                int userChoice = inputManager.GetUserChoice();
                MainMenuChoices mainMenuChoice = (MainMenuChoices)userChoice;
                MakeInitialChoice(mainMenuChoice);
            }
        }

        /// <summary>
        /// Processes the user's choice from the main menu and performs the corresponding action.
        /// </summary>
        /// <param name="choice">The user's selected option from the main menu, represented as an enum of type <see cref="MainMenuChoices"/>.</param>
        public void MakeInitialChoice(MainMenuChoices choice)
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
                        Console.Clear();
                        inventoryManager.EditProduct();
                        break;
                    case MainMenuChoices.deleteProduct:
                        inventoryManager.DeleteProduct();
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
