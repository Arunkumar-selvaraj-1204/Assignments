using InventoryManager.Model;
namespace InventoryManager.Utils
{
    internal class ProductValidator
    {
        /// <summary>
        /// Validates if the given product ID is valid.
        /// A valid product ID is non-empty, non-whitespace, and has a maximum length of 5 characters.
        /// </summary>
        /// <param name="productId">The product ID to validate.</param>
        /// <returns>true if the product ID is valid; otherwise, false.</returns>
        public static bool IsValidProductId(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId) || productId.Length > 5)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if the given product name is valid.
        /// A valid product name is non-empty, contains at least one letter, and is not whitespace.
        /// </summary>
        /// <param name="productName">The product name to validate.</param>
        /// <returns>true if the product name is valid; otherwise, false.</returns>
        public static bool IsValidProductName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName) || !productName.Any(char.IsLetter))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if the given product price is valid.
        /// A valid price is a positive float value greater than zero.
        /// </summary>
        /// <param name="price">The price to validate as a string.</param>
        /// <param name="invalidMessage">An output parameter that contains an error message if the price is invalid.</param>
        /// <returns>true if the price is valid; otherwise, false.</returns>
        public static bool IsValidProductPrice(string price, out string invalidMessage)
        {
            float value;
            if (string.IsNullOrWhiteSpace(price) || !float.TryParse(price, out value)) {
                invalidMessage = "Price should be int or float.";
                return false;
            }
            if (value <= 0)
            {
                invalidMessage = "Price cannot be negative or zero";
                return false;
            }
            invalidMessage = null;
            return true;

        }

        /// <summary>
        /// Validates if the given product quantity is valid.
        /// A valid quantity is a positive integer or zero.
        /// </summary>
        /// <param name="quantity">The quantity to validate as a string.</param>
        /// <returns>true if the quantity is valid; otherwise, false.</returns>
        public static bool IsValidProductQuantity(string quantity)
        {
            if (string.IsNullOrWhiteSpace(quantity) || !int.TryParse(quantity, out int value) || value < 0)
            {
                Console.WriteLine("Quantity Should be a positive integer");
                return false;
            }
            return true;

        }

        /// <summary>
        /// Validates if the given input is either a valid product ID or product name.
        /// </summary>
        /// <param name="userInput">The input to validate.</param>
        /// <returns>true if the input is valid; otherwise, false.</returns>
        public static bool IsValidProductIdOrName(string userInput)
        {
            if ((string.IsNullOrWhiteSpace(userInput)))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is a duplicate product ID in the product list.
        /// </summary>
        /// <param name="productList">The list of products to check for duplicates.</param>
        /// <param name="userInput">The input to check for duplicate ID or name.</param>
        /// <returns>true if the input is a duplicate; otherwise, false.</returns>
        public static bool IsDuplicateId(List<Product> productList, string userInput)
        {
            foreach (Product product in productList)
            {
                if(product.ProductId == userInput)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the given input is a duplicate product name in the product list.
        /// </summary>
        /// <param name="productList">The list of products to check for duplicates.</param>
        /// <param name="userInput">The input to check for duplicate ID or name.</param>
        /// <returns>true if the input is a duplicate; otherwise, false.</returns>
        public static bool IsDuplicateName(List<Product> productList, string userInput)
        {
            foreach (Product product in productList)
            {
                if (product.ProductName == userInput)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
