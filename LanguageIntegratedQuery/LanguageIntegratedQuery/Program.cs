namespace LanguageIntegratedQuery
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ProductGenerator productGenerator = new ProductGenerator();
            Task1 task1 = new Task1(productGenerator.GetProductList());
            task1.Run();
        }
        

        
    }
}
