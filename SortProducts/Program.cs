namespace SortProducts
{
    public delegate int SortDelegate (Product firstProduct, Product secondProduct);
    internal class Program
    {
        static void Main(string[] args)
        {
           
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
    }
}
