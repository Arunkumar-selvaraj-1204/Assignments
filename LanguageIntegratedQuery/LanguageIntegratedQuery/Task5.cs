using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class Task5
    {
        QueryBuilder<Product> queryBuilder;

        public Task5(List<Product> products, List<Supplier> suppliers)
        {
            queryBuilder = new QueryBuilder<Product>(products, suppliers);
        }

        public void Run()
        {
            DisplayProductNameContains2();
            DisplayProductCategoryStartsWithE();
            JoinProductsWithSuppliers();
        } 

        private void DisplayProductNameContains2()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 5.1: Display product name contains '2'");
            Console.ResetColor();

            var result = queryBuilder.Filter(product => product.ProductName.Contains("2")).Execute();
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "ProductId", "ProductName", "Price", "Category");
            Console.WriteLine(new string('-', 60));

            foreach (Product item in result)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}",
                    item.ProductId,
                    item.ProductName,
                    $"RS. {item.ProductPrice}",
                    item.Category);
            }
        }
        
        private void DisplayProductCategoryStartsWithE()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 5.2: Display products whose category starts with 'E' and sort by price");
            Console.ResetColor();

            var result = queryBuilder.Filter(product => product.Category.StartsWith("E")).SortBy(product => product.ProductPrice).Execute();
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "ProductId", "ProductName", "Price", "Category");
            Console.WriteLine(new string('-', 60));

            foreach (Product item in result)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}",
                    item.ProductId,
                    item.ProductName,
                    $"RS. {item.ProductPrice}",
                    item.Category);
            }
        }

        private void JoinProductsWithSuppliers()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 5.3: Products with price less than 100 and sorted by price and performed Inner join with Supplier using Supplier ID");
            Console.ResetColor();

            var result = queryBuilder.Filter(product => product.ProductPrice < 100).SortBy(product => product.ProductPrice).Join((p,s) => p.ProductId == s.ProductId).Execute();
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} ", "ProductId", "ProductName", "Supplier Name","Price");
            Console.WriteLine(new string('-', 60));

            foreach (Tuple<int,string,string,decimal> item in result)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} ",
                    item.Item1,
                    item.Item2,
                    item.Item3,
                    item.Item4
                    );
            }
        }
    }
}
