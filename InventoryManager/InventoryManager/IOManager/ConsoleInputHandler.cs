using InventoryManager.Model;
using InventoryManager.Utils;


namespace InventoryManager.IOManager
{
    internal class ConsoleInputHandler
    {
        private List<Product> _productList;

        public ConsoleInputHandler(List<Product> productList)
        {
            _productList = productList;
        }

        public ConsoleInputHandler() { 

        }

        /// <summary>
        /// Prompts the user to enter a menu choice and validates the input as an integer.
        /// </summary>
        /// <returns>A valid integer representing the user's choice.</returns>
        public int GetUserChoice()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                ConsoleOutputHandler.PrintInvalidOption("");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }

        /// <summary>
        /// Collects product details from the user and creates a new Product object.
        /// </summary>
        /// <returns>A Product object containing the entered details.</returns>
        public Product GetProductDetails()
        {
            string productId = GetProductId(true);
            string productName = GetProductName(true);
            float price = GetPrice();
            int quantity = GetQuantity();
            return new Product(productId, productName, price, quantity);
        }

        /// <summary>
        /// Prompts the user to enter a product ID and validates it.
        /// Optionally checks for duplicate IDs in the product list.
        /// </summary>
        /// <param name="checkDuplicate">Whether to check for duplicate product IDs.</param>
        /// <returns>A valid product ID string.</returns>
        public string GetProductId(bool checkDuplicate = false)
        {
            Console.Write("Enter Product ID: ");
            string productId = Console.ReadLine();
            while (!ProductValidator.IsValidProductId(productId) || (checkDuplicate ? ProductValidator.IsDuplicateId(_productList, productId) : false))
            {
                if (checkDuplicate ? ProductValidator.IsDuplicateId(_productList, productId) : false)
                {
                    ConsoleOutputHandler.PrintInvalidInput("Product name should not be duplicate");
                }
                else
                {
                    ConsoleOutputHandler.PrintInvalidInput("Product id should be less than 5 chars.");
                }
                Console.Write("Enter Product ID: ");
                productId = Console.ReadLine();
            }
            return productId;
        }

        /// <summary>
        /// Prompts the user to enter a product name and validates it.
        /// Optionally checks for duplicate names in the product list.
        /// </summary>
        /// <param name="checkDuplicate">Whether to check for duplicate product names.</param>
        /// <returns>A valid product name string.</returns>
        public string GetProductName(bool checkDuplicate = false)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            while (!ProductValidator.IsValidProductName(productName) || (checkDuplicate ? ProductValidator.IsDuplicateName(_productList, productName) : false))
            {
                if (checkDuplicate ? ProductValidator.IsDuplicateName(_productList, productName) : false)
                {
                    ConsoleOutputHandler.PrintInvalidInput("Product name should not be duplicate.");
                }
                else
                {
                    ConsoleOutputHandler.PrintInvalidInput("Product Name should not have only numbers or empty.");
                }
                Console.Write("Enter Product Name: ");
                productName = Console.ReadLine();
            }
            return productName;
        }


        /// <summary>
        /// Prompts the user to enter the product price and validates it.
        /// </summary>
        /// <returns>A valid float value representing the product price.</returns>
        public float GetPrice()
        {
            Console.Write("Enter Product Price: ");
            string userInput = Console.ReadLine();
            float price;
            while (!ProductValidator.IsValidProductPrice(userInput, out string invalidMessage))
            {
                ConsoleOutputHandler.PrintInvalidOption(invalidMessage);
                Console.Write("Enter Product Price: ");
                userInput = Console.ReadLine();
            }
            price = float.Parse(userInput);
            return price;
        }


        /// <summary>
        /// Prompts the user to enter the product quantity and validates it.
        /// </summary>
        /// <returns>A valid integer value representing the product quantity.</returns>
        public int GetQuantity()
        {
            Console.Write("Enter Product Quantity: ");
            string quantity = Console.ReadLine();
            while (!ProductValidator.IsValidProductQuantity(quantity))
            {
                Console.Write("Enter Product quantity: ");
                quantity = Console.ReadLine();
            }
            return int.Parse(quantity);
        }

        /// <summary>
        /// Prompts the user to enter either a product ID or product name and validates the input.
        /// </summary>
        /// <returns>A valid string representing the product ID or name.</returns>
        public string GetProductNameorId()
        {
            Console.Write("Enter product ID/Name: ");
            string userInput = Console.ReadLine();
            while (!ProductValidator.IsValidProductIdOrName(userInput))
            {
                ConsoleOutputHandler.PrintInvalidInput("Note: Product Name should not be a number.");
                Console.Write("Enter product ID/Name: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        /// <summary>
        /// Displays a message prompting the user to press any key to continue.
        /// </summary>
        public void PressKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


        /// <summary>
        /// Prompts the user to confirm an action by typing "Y" or "y".
        /// </summary>
        public bool GetConfirmation()
        {
            Console.Write("Enter Y/y to confirm: ");
            string confirmation = Console.ReadLine();
            confirmation = confirmation.ToLower();
            if (confirmation != null && (confirmation == "yes" || confirmation == "y"))
            {
                return true;
            }
            return false;
        }
    }
}
