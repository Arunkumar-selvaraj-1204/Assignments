using ConsoleTables;
using Spectre.Console;

namespace SortProducts
{
    public delegate int SortDelegate (Product firstProduct, Product secondProduct);
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = GetProducts();
            Console.WriteLine("The product list:");
            ConsoleTable consoleTable = new ConsoleTable("Name", "Category", "Price");
            foreach (var product in products)
            {
                consoleTable.AddRow(product.ProductName, product.Category, product.Price);
            }
            consoleTable.Write();
            bool isExit = false;
            while (!isExit)
            {
                var choice = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                     .Title("Select a option to sort products:")
                     .PageSize(10)
                     .AddChoices(new[] {
                    "Sort by name",
                    "Sort by category",
                    "Sort by price",
                    "Exit"
                     }));
                switch (choice)
                {
                    case "Sort by name":
                        SortAndDisplay(SortByName, products);
                        break;
                    case "Sort by category":
                        SortAndDisplay(SortByCategory, products);
                        break;
                    case "Sort by price":
                        SortAndDisplay(SortByPrice, products);
                        break;
                    default:
                        isExit = true;
                        break;
                }
            }
        }
        public static int SortByName(Product firstProduct, Product secondProduct)
        {
            return String.Compare(firstProduct.ProductName, secondProduct.ProductName);
        }

        public static int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return String.Compare(firstProduct.Category, secondProduct.Category);
        }

        public static int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }

        public static void SortAndDisplay(SortDelegate sortMethod, List<Product> products)
        {
            var tempProducts = new List<Product>(products);
            tempProducts.Sort(sortMethod.Invoke);
            ConsoleTable consoleTable = new ConsoleTable("Name", "Category", "Price");

            foreach (Product product in tempProducts)
            {
                consoleTable.AddRow(product.ProductName, product.Category, product.Price);
            }

            consoleTable.Write();
        }
        private static List<Product> GetProducts()
        {
            bool confirm = AnsiConsole.Confirm("Do you want to create your own product list or go with Default list?");
            if (confirm)
            {
                Console.Write("Enter the number of products: ");
                int count;
                while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer:");
                }

                var products = new List<Product>();

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\nEnter details for product {i + 1}:");

                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category: ");
                    string category = Console.ReadLine();

                    double price;
                    Console.Write("Price: ");
                    while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid non-negative price:");
                    }

                    products.Add(new Product
                    {
                        ProductName = name,
                        Category = category,
                        Price = price
                    });
                }

                return products;
            }
            else
            {
                return new List<Product>
        {
            new Product { ProductName = "Laptop",     Category = "Electronics", Price = 899.99 },
            new Product { ProductName = "Notebook",   Category = "Stationery",  Price = 2.49 },
            new Product { ProductName = "Coffee Mug", Category = "Kitchenware", Price = 7.95 },
            new Product { ProductName = "Headphones", Category = "Electronics", Price = 129.99 },
            new Product { ProductName = "Desk Chair", Category = "Furniture",   Price = 89.99 },
            new Product { ProductName = "Pen Set",    Category = "Stationery",  Price = 5.99 },
            new Product { ProductName = "Backpack",   Category = "Accessories", Price = 39.99 },
            new Product { ProductName = "Water Bottle",Category = "Fitness",    Price = 15.49 }
        };
            }
        }
    }
}
