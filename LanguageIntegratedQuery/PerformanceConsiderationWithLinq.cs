using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class PerformanceConsiderationWithLinq
    {
        private List<Product> _products;

        public PerformanceConsiderationWithLinq(List<Product> productList)
        {
            _products = productList;
        }

        /// <summary>
        ///  Displays all books sort by price.
        /// </summary>
        public void Run()
        {
            IEnumerable<Product> books = _products.Where(product => product.Category == "Books").OrderBy(p => p.ProductPrice);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 4: Display all books sort by price.");
            Console.ResetColor();

            Console.WriteLine("{0,-10} {1,-20} {2,10}", "ProductId", "ProductName", "Price");
            Console.WriteLine(new string('-', 40));
            foreach (Product book in books)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,10}",
                    book.ProductId,
                    book.ProductName,
                    $"RS. {book.ProductPrice}");
            }

        }
    }
}
