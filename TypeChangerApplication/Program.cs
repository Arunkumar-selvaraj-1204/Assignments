using System;
namespace UseOfDynamicAndVar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string message = Console.ReadLine() ?? "Default string";
            var valueChangingVariable = message;
            Console.WriteLine($"Value of the variable declared with 'var' keyword is - {valueChangingVariable}");

            // The below line when executed will show the error "Cannot implicitly convert type 'int' to 'string'" denoting that the type of the variables declared with 'var' keyword cannot be changed.
            // valueChangingVariable = 90;
            // Console.WriteLine(valueChangingVariable);

            dynamic dynamicVariable = message;
            Console.WriteLine($"Initial value of the variable declared with 'dynamic' keyword is - {dynamicVariable} and it's type is {dynamicVariable.GetType()}");

            dynamicVariable = 20.543;
            Console.WriteLine($"Modified value of the variable declared with 'dynamic' keyword is - {dynamicVariable} and it's type is {dynamicVariable.GetType()}");
            Console.WriteLine("For more details about var and dynamic keyword, Please checkout README.md :)");
        }
    }
}
