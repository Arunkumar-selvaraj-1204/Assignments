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
    /// <summary>
    /// Adds a new product to the inventory by getting the product details from the user.
    /// </summary>

    public void AddProduct()
    {
        OutputManager.PrintCurrentTask("ADD");
        Product product = inputManager.GetProductDetails();
        _productList.Add(product);
        OutputManager.PrintSuccessMessage("Product added successfully");
        inputManager.PressKeyToContinue();
        OutputManager.ClearConsoleAndPrintMenu();
    }

    /// <summary>
    /// Displays all products in the inventory in a tabular format.
    /// </summary>
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

    /// <summary>
    /// Searches for a product in the inventory by product ID or name. Displays the product details if found.
    /// </summary>
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

    /// <summary>
    /// Edits the details of an existing product in the inventory by allowing the user to select and modify fields.
    /// </summary>
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


    /// <summary>
    /// Deletes a product from the inventory after confirming the action with the user.
    /// </summary>
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

    /// <summary>
    /// Searches for a product in the inventory by its ID or name.
    /// </summary>
    /// <param name="productIdOrName">The ID or name of the product to search for.</param>
    /// <returns>
    /// The <see cref="Product"/> object if found, otherwise null.
    /// </returns>
    private Product FindProduct(string productIdOrName)
    {
        foreach(Product product in _productList)
        {
            if(product.ProductName == productIdOrName) return product;
            if (product.ProductId == productIdOrName) return product;
        }
        return null;
    }

    /// <summary>
    /// Edits the specified product based on the user's choice of which attribute to modify.
    /// </summary>
    /// <param name="product">The product object to be edited.</param>
    /// <param name="editChoice">The user's choice of which attribute to edit, represented as an <see cref="EditChoice"/> enum.</param>
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
