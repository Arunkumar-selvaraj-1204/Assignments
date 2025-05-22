using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageIntegratedQuery
{
    internal class ComplexLinqQueries
    {
        private List<Product> _products;
        public List<Supplier> suppliers { get; set; }

        string[] _categories;

        public ComplexLinqQueries(List<Product> productList, string[] categories)
        {
            _products = productList;
            suppliers = GenerateSupplierList();
            _categories = categories;
        }
        public void Run()
        {
            RunTask2_1();
            RunTask2_2();
         }

        /// <summary>
        /// Displays product grouped by category and its expensive product detail.
        /// </summary>
        private void RunTask2_1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 2.1: Grouped by category and its expensive product detail.");
            Console.ResetColor();

            Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,10}", "Category", "Count", "Expensive Product", "Price");
            Console.WriteLine(new string('-', 60));

            foreach (string category in _categories)
            {
                int productCount = _products.Count(product => product.Category == category);
                Product expensiveProduct = _products.Where(product => product.Category == category)
                                            .OrderByDescending(product => product.ProductPrice)
                                            .FirstOrDefault();

                Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,10}",
                    category,
                    productCount,
                    expensiveProduct?.ProductName ?? "N/A",
                    $"RS. {expensiveProduct?.ProductPrice ?? 0}");
            }
        }

        /// <summary>
        /// Prints supplier name of the products.
        /// </summary>
        private void RunTask2_2()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nTask 2.2: Print supplier name of the products.");
            Console.ResetColor();

            List<Supplier> supplierList = GenerateSupplierList();
            IEnumerable<(int productId, string productName, string supplierName)> supplierOfProducts = _products.Join(supplierList, product => product.ProductId, supplier => supplier.ProductId, (product, supplier) => (product.ProductId, product.ProductName, supplier.SupplierName));
            Console.WriteLine("{0,-10} {1,-25} {2,-25}", "ProductId", "ProductName", "SupplierName");
            Console.WriteLine(new string('-', 65));
            foreach (var productData in supplierOfProducts)
            {
                Console.WriteLine("{0,-10} {1,-25} {2,-25}",
                    productData.productId,
                    productData.productName,
                    productData.supplierName);
            }
        }

        /// <summary>
        /// Generates a static supplier list.
        /// </summary>
        /// <returns>supplier list</returns>
        private List<Supplier> GenerateSupplierList()
        {
            List <Supplier> suppliers = new List<Supplier>()
            {
                new  Supplier{SupplierId = 1, SupplierName = "Supplier 1", ProductId = 15 },
                new  Supplier{SupplierId = 1, SupplierName = "Supplier 1", ProductId = 12 },
                new  Supplier{SupplierId = 1, SupplierName = "Supplier 1", ProductId = 10 },
                new  Supplier{SupplierId = 2, SupplierName = "Supplier 2", ProductId = 14 },
                new  Supplier{SupplierId = 2, SupplierName = "Supplier 2", ProductId = 13 },
                new  Supplier{SupplierId = 3, SupplierName = "Supplier 3", ProductId = 11 },
                new  Supplier{SupplierId = 3, SupplierName = "Supplier 3", ProductId = 9 },
                new  Supplier{SupplierId = 3, SupplierName = "Supplier 3", ProductId = 8 },
                new  Supplier{SupplierId = 4, SupplierName = "Supplier 4", ProductId = 2 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 7 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 6 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 4 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 5 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 3 },
                new  Supplier{SupplierId = 5, SupplierName = "Supplier 5", ProductId = 1 },
            };
            return suppliers;
        }
    }

}
