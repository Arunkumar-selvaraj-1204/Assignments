namespace LanguageIntegratedQuery
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ProductGenerator productGenerator = new ProductGenerator();
            DisplayAllProducts(productGenerator.GetProductList());
            BasicLinqQueries basicLinqQueries = new BasicLinqQueries(productGenerator.GetProductList());
            basicLinqQueries.Run();
            ComplexLinqQueries complexLinqQueries = new ComplexLinqQueries(productGenerator.GetProductList(), productGenerator.GetCategories());
            complexLinqQueries.Run();
            LinqToObject linqToObject = new LinqToObject();
            linqToObject.Run();
            PerformanceConsiderationWithLinq performanceConsiderationWithLinq = new PerformanceConsiderationWithLinq (productGenerator.GetProductList());
            performanceConsiderationWithLinq.Run();
            LinqQueryBuilder linqQueryBuilder = new LinqQueryBuilder(productGenerator.GetProductList(), complexLinqQueries.suppliers); //Suppliers list is generated in task2
            linqQueryBuilder.Run();
        }

        /// <summary>
        /// Display all product data.
        /// </summary>
        /// <param name="products">List of products</param>
        public static void DisplayAllProducts(List<Product> products)
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "ProductId", "ProductName", "Price", "Category");
            Console.WriteLine(new string('-', 60));
            foreach (Product product in products)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}",
                    product.ProductId,
                    product.ProductName,
                    $"RS. {product.ProductPrice}",
                    product.Category);
            }
        }
        
    }
}
