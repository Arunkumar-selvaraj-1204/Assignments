

namespace InventoryManager.Model
{
    internal class Product
    {
        public Product(string productId, string productName, float price, int quantityInStock)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            QuantityInStock = quantityInStock;
        }
        public string ProductId { get; set; }
        public string ProductName {get; set;}
        public float Price {get; set;}
        public int QuantityInStock {get; set;}

    
    }
}
