using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class Task2
    {
        private List<Product> _products;
        string[] _categories;

        public Task2(List<Product> productList, string[] categories)
        {
            _products = productList;
            _categories = categories;
        }
        public void Run()
        {
            RunTask2_1();
            RunTask2_2();


         }

        private void RunTask2_1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 2.1: Grouped by category and its expensive product detail.");
            Console.ResetColor();

            Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,10}", "Category", "Count", "Expensive Product", "Price");
            Console.WriteLine(new string('-', 60));

            foreach (string category in _categories)
            {
                int productCount = _products.Count(product => product.Category == category);
                Product expensiveProduct = _products
                    .Where(product => product.Category == category)
                    .OrderByDescending(product => product.ProductPrice)
                    .FirstOrDefault();

                Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,10}",
                    category,
                    productCount,
                    expensiveProduct?.ProductName ?? "N/A",
                    $"RS. {expensiveProduct?.ProductPrice ?? 0}");
            }
        }
        private void RunTask2_2()
        {
            
        }
    }

}
