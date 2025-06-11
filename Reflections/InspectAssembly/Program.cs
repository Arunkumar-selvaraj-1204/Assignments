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
            DisplayMetaData(helperType, helperInstance);
            

            //Task 2
            var objectInspector = new DynamicObjectInspector(assembly);
            objectInspector.DisplayProerties();
            string choice = GetPropertyToChange();
            while (!objectInspector.ChangePropertyValue(choice))
            {
                Console.WriteLine("Property not found");
                choice = GetPropertyToChange();
            }
            Console.WriteLine("Value changed successfully...");
            objectInspector.DisplayProerties();

            //Task 3
            var methodInvoker = new DynamicMethodInvoker(assembly);
            int number1 = GetNumber();
            int number2 = GetNumber();
            methodInvoker.AddTwoNumber(number1, number2 );
        }

        private static string GetPropertyToChange()
        {
            Console.Write("Enter the property name (Case sensitive): ");
            return Console.ReadLine();
        }
        private static void DisplayMetaData(Type helperType, object helperInstance)
        {
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
        private static int GetNumber()
        {
            Console.Write("Enter a number: ");
            int result;
            while (int.TryParse(Console.ReadLine(), out result)){
                Console.Write("Enter valid integer: ");
            }
            return result;
        }

        
    }
}
