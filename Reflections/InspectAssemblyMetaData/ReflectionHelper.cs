namespace InspectAssemblyMetaData
{
    public class ReflectionHelper
    {
        public string Name { get; set; }
        public int Version { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Version: {Version}");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
