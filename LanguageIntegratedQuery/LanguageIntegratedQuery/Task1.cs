using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class Task1
    {
        private List<Product> _products;

        public Task1(List<Product> productList)
        {
            _products = productList;
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 1: Electronics priced greater than 500, sorted by price in descending order.");
            Console.ResetColor();
            IEnumerable<(string productName, decimal productPrice)> electronicsGreaterThan500 = _products.Where(product => product.Category == "Electronics" && product.ProductPrice > 500).Select(product => ( product.ProductName, product.ProductPrice));
            IEnumerable<(string productName, decimal productPrice)> selectedProductsInDesc = electronicsGreaterThan500.OrderByDescending(product => product.productPrice);
            DisplayProducts(selectedProductsInDesc);
        }

        private void DisplayProducts(IEnumerable<(string productName, decimal productPrice)> products)
        {
            Console.WriteLine("{0,-20} {1,10}", "Product Name", "Product Price");
            Console.WriteLine(new string('-', 40));

            foreach (var product in products)
            {
                Console.WriteLine("{0,-20} {1,10}", product.productName, $"RS. {product.productPrice}");
            }
        }
    }
}
