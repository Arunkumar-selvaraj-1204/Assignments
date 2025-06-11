using System.Reflection;

namespace InspectAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("../../../InspectAssemblyMetaData.dll");
            Type helperType = assembly.GetType("ReflectionHelper.Helper");
            object helperInstance = Activator.CreateInstance(helperType);

            Console.WriteLine("=== Fields ===");
            foreach (var field in helperType.GetFields())
            {
                Console.WriteLine($"{field.Name} = {field.GetValue(helperInstance)}");
            }

            Console.WriteLine("=== Properties ===");
            foreach (var prop in helperType.GetProperties())
            {
                Console.WriteLine($"{prop.Name} = {prop.GetValue(helperInstance)}");
            }

            Console.WriteLine("=== Methods ===");
            foreach (var method in helperType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("=== Events ===");
            foreach (var ev in helperType.GetEvents())
            {
                Console.WriteLine(ev.Name);
            }
        }

        private static string GetName()
        {
            Console.Write("Enter your name to change in the dll: ");
            return Console.ReadLine();
        }
        private static int GetVersion()
        {
            Console.Write("Enter the version to change in dll: ");
            int result;
            while (int.TryParse(Console.ReadLine(), out result)){
                Console.Write("Enter valid integer: ");
            }
            return result;
        }

        private static int GetNumber()
        {
            Console.Write("Enter a number: ");
            int result;
            while (int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Enter valid integer: ");
            }
            return result;
        }
    }
}
