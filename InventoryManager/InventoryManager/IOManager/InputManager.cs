using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Model;
using InventoryManager.Utils;


namespace InventoryManager.IOManager
{
    internal class InputManager
    {

        public static int GetUserChoice()
        {
            Console.Write("Enter choice: ");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                OutputManager.PrintInvalidOption("");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }

        public static Product GetProductDetails()
        {
            string productId = GetProductId();
            string productName = GetProductName();
            float price = GetPrice();
            int quantity = GetQuantity();
            return new Product(productId, productName, price, quantity);
        }

        private static string GetProductId()
        {
            Console.Write("Enter Product ID: ");
            string productId = Console.ReadLine();
            while (!Validator.IsValidProductId(productId))
            {
                OutputManager.PrintInvalidInput("Product id should be less than 5 chars");
                Console.Write("Enter Product ID: ");
                productId = Console.ReadLine();
            }
            return productId;
        }

        private static string GetProductName()
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            while (!Validator.IsValidProductName(productName))
            {
                OutputManager.PrintInvalidInput("Product Name should not have only numbers or empty");
                Console.Write("Enter Product Name: ");
                productName = Console.ReadLine();
            }
            return productName;
        }

        private static float GetPrice()
        {
            Console.Write("Enter Product Price: ");
            string userInput = Console.ReadLine();
            float price;
            while (!Validator.IsValidProductPrice(userInput, out string invalidMessage))
            {
                OutputManager.PrintInvalidOption(invalidMessage);
                Console.Write("Enter Product Price: ");
                userInput = Console.ReadLine();
            }
            price = float.Parse(userInput);
            return price;
        }

        private static int GetQuantity()
        {
            Console.Write("Enter Product Quantity: ");
            string quantity = Console.ReadLine();
            while (!Validator.IsValidProductQuantity(quantity))
            {
                Console.Write("Enter Product quantity: ");
                quantity = Console.ReadLine();
            }
            return int.Parse(quantity);
        }
    }
}
