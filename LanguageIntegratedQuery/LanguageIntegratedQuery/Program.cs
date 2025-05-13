namespace LanguageIntegratedQuery
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ProductGenerator productGenerator = new ProductGenerator();
            DisplayAllProducts(productGenerator.GetProductList());
            Task1 task1 = new Task1(productGenerator.GetProductList());
            task1.Run();
            Task2 task2 = new Task2(productGenerator.GetProductList(), productGenerator.GetCategories());
            task2.Run();
            Task3 task = new Task3();
            task.Run();
            Task4 task4 = new Task4 (productGenerator.GetProductList());
            task4.Run();
            Task5 task5 = new Task5(productGenerator.GetProductList(), task2.suppliers); //Suppliers list is generated in task2
            task5.Run();
        }

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
