using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class ProductGenerator
    {
        private static readonly string[] Categories = { "Electronics", "Clothing", "Grocery", "Books", "Entertainment" };
        private static readonly Random RandomGenerator = new Random();
        private List<Product> productList;
        int noOfProducts;
        public ProductGenerator()
        {
            noOfProducts = 15;
            productList = new List<Product>();
            CreateProducts(productList, noOfProducts);
        }

        public List<Product> GetProductList() { return productList; }
        public string[] GetCategories() { return Categories; }

        /// <summary>
        /// Creates a specified number of products and ensures each category appears at least once.
        /// </summary>
        /// <param name="productList">The list to store products.</param>
        /// <param name="count">The number of products to create.</param>
        public static void CreateProducts(List<Product> productList, int count)
        {
            List<string> remainingCategories = new List<string>(Categories);

            for (int i = 1; i <= count; i++)
            {
                string category;

                if (remainingCategories.Count > 0)
                {
                    int index = RandomGenerator.Next(remainingCategories.Count);
                    category = remainingCategories[index];
                    remainingCategories.RemoveAt(index);
                }
                else
                {
                    category = PickRandomCategory();
                }

                var product = new Product
                {
                    ProductId = i,
                    ProductName = $"Product {i}",
                    ProductPrice = GenerateRandomPrice(),
                    Category = category
                };

                productList.Add(product);
            }
        }

        /// <summary>
        /// Displays the list of products in a formatted manner.
        /// </summary>
        /// <param name="productList">The list of products to display.</param>
        public static void DisplayProducts(List<Product> productList)
        {
            Console.WriteLine("\n--- Product List ---");
            foreach (var product in productList)
            {
                Console.WriteLine($"ID: {product.ProductId}," +
                    $" Name: {product.ProductName}," +
                    $" Price: {product.ProductPrice:C}," +
                    $" Category: {product.Category}");
            }
        }

        /// <summary>
        /// Generates a random price between 10.00 and 1000.00.
        /// </summary>
        /// <returns>A random decimal price.</returns>
        public static decimal GenerateRandomPrice()
        {
            return Math.Round((decimal)(RandomGenerator.NextDouble() * (1000 - 10) + 10), 2);
        }

        /// <summary>
        /// Picks a random category from the predefined category array.
        /// </summary>
        /// <returns>A random category as a string.</returns>
        public static string PickRandomCategory()
        {
            int index = RandomGenerator.Next(Categories.Length);
            return Categories[index];
        }
    }
}
