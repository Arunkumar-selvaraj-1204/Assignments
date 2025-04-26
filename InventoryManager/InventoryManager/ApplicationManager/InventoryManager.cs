using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.IOManager;
using InventoryManager.Model;
using static InventoryManager.Model.ApplicationEnums;
namespace InventoryManager.ApplicationManager;

internal class InventoryManager
{
    private static List<Product> _productList = new List<Product>(); 

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

    public void SearchProduct()
    {
        OutputManager.PrintCurrentTask("SEARCH");
        string productIdOrName = InputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct);
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
        else
        {
            OutputManager.PrintErrorMessage("Product Not Found!");
        }
    }

    public void EditProduct()
    {
        OutputManager.PrintCurrentTask("EDIT");
        string productIdOrName = InputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct, true);
            int userChoice = InputManager.GetUserChoice();
            PerformEdit(searchedProduct, (EditChoice)userChoice);
            OutputManager.PrintSuccessMessage("product edited successfully");
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
        else
        {
            OutputManager.PrintErrorMessage("Product Not Found!");
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
    }

    public void DeleteProduct()
    {

        OutputManager.PrintCurrentTask("DELETE");
        string productIdOrName = InputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct, true);
            if (InputManager.GetConfirmation())
            {
                _productList.Remove(searchedProduct);
                OutputManager.PrintSuccessMessage("product deleted successfully");
            }
            else
            {
                OutputManager.PrintErrorMessage("Confirmation denied");
            }
                InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
        else
        {
            OutputManager.PrintErrorMessage("Product Not Found!");
            InputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
    }


    //helper functions
    private static Product FindProduct(string productIdOrName)
    {
        foreach(Product product in _productList)
        {
            if(product.ProductName == productIdOrName) return product;
            if (product.ProductId == productIdOrName) return product;
        }
        return null;
    }

    private void PerformEdit(Product product, EditChoice editChoice)
    {
        switch (editChoice)
        {
            case EditChoice.productId:
                string productId = InputManager.GetProductId();
                product.ProductId = productId;
                break;
            case EditChoice.productName:
                string productName = InputManager.GetProductName();
                product.ProductName = productName;
                break;
            case EditChoice.productPrice:
                float price = InputManager.GetPrice();
                product.Price = price;
                break;
            case EditChoice.productQuantity: 
                int quantity = InputManager.GetQuantity();
                product.QuantityInStock = quantity;
                break;
            default:
                OutputManager.PrintInvalidInput("Enter between 1- 4.");
                break;


        }
    }
}
