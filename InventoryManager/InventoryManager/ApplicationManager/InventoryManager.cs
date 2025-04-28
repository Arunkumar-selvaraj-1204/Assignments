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
    private List<Product> _productList;
    InputManager inputManager;

    public InventoryManager(List<Product> productList)
    {
        _productList = productList;
        inputManager = new InputManager(_productList);
    }


    public IEnumerable<Product> GetProductList()
    {
        return _productList;
    }
    public void AddProduct()
    {
        OutputManager.PrintCurrentTask("ADD");
        Product product = inputManager.GetProductDetails();
        _productList.Add(product);
        OutputManager.PrintSuccessMessage("Product added successfully");
        inputManager.PressKeyToContinue();
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
        inputManager.PressKeyToContinue();
        OutputManager.ClearConsoleAndPrintMenu();
    }

    public void SearchProduct()
    {
        OutputManager.PrintCurrentTask("SEARCH");
        string productIdOrName = inputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct);
            inputManager.PressKeyToContinue();
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
        string productIdOrName = inputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct, true);
            int userChoice = inputManager.GetUserChoice();
            PerformEdit(searchedProduct, (EditChoice)userChoice);
            OutputManager.PrintSuccessMessage("product edited successfully");
            inputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
        else
        {
            OutputManager.PrintErrorMessage("Product Not Found!");
            inputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
    }

    public void DeleteProduct()
    {

        OutputManager.PrintCurrentTask("DELETE");
        string productIdOrName = inputManager.GetProductNameorId();
        Product searchedProduct = FindProduct(productIdOrName);
        if (searchedProduct != null)
        {
            OutputManager.ShowProductDetail(searchedProduct, true);
            if (inputManager.GetConfirmation())
            {
                _productList.Remove(searchedProduct);
                OutputManager.PrintSuccessMessage("product deleted successfully");
            }
            else
            {
                OutputManager.PrintErrorMessage("Confirmation denied");
            }
                inputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
        else
        {
            OutputManager.PrintErrorMessage("Product Not Found!");
            inputManager.PressKeyToContinue();
            OutputManager.ClearConsoleAndPrintMenu();
        }
    }


    //helper functions
    private Product FindProduct(string productIdOrName)
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
                string productId = inputManager.GetProductId(true);
                product.ProductId = productId;
                break;
            case EditChoice.productName:
                string productName = inputManager.GetProductName(true);
                product.ProductName = productName;
                break;
            case EditChoice.productPrice:
                float price = inputManager.GetPrice();
                product.Price = price;
                break;
            case EditChoice.productQuantity: 
                int quantity = inputManager.GetQuantity();
                product.QuantityInStock = quantity;
                break;
            default:
                OutputManager.PrintInvalidInput("Enter between 1- 4.");
                break;


        }
    }
}
