using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.IOManager;
using InventoryManager.Model;
namespace InventoryManager.ApplicationManager
{
    internal class InventoryManager
    {
        private List<Product> _productList = new List<Product>(); 

        public void AddProduct()
        {
            OutputManager.PrintCurrentTask("ADD");
            Product product = InputManager.GetProductDetails();
            _productList.Add(product);
            OutputManager.PrintSuccessMessage("Product added successfully");
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }

        public void ViewAllProducts()
        {
            OutputManager.PrintCurrentTask("VIEW");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-10} | {1,-20} | {2,8} | {3,5} |",
                                             "Product ID", "Product Name", "Price", "Stock"));
            Console.WriteLine("------------------------------------------------------------");

            foreach (Product product in _productList)
            {
                Console.WriteLine(String.Format("| {0,-10} | {1,-20} | {2,8} | {3,5} |",
                                                 product.ProductId, product.ProductName, $"Rs. {product.Price}", product.QuantityInStock));
            }

            Console.WriteLine("------------------------------------------------------------");
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
    }
}
