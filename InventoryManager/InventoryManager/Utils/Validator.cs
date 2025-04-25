namespace InventoryManager.Utils
{
    internal class Validator
    {
        public static bool IsValidProductId(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId) || productId.Length > 5)
            {
                return false;
            }
            return true;
        }
        public static bool IsValidProductName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName) || !productName.Any(char.IsLetter))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidProductPrice(string price, out string invalidMessage)
        {
            float value;
            if (!float.TryParse(price, out value)) {
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
        public static bool IsValidProductQuantity(string quantity)
        {
            if (!int.TryParse(quantity, out int value) || value < 0)
            {
                Console.WriteLine("Quantity Should be a positive integer");
                return false;
            }
            return true;

        }

    }
}
