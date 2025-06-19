using System;
using System.Diagnostics;
using Spectre.Console;

namespace SerializationAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = AnsiConsole.Ask<string>("Enter [yellow]Product Name[/]:");
            int id = AnsiConsole.Ask<int>("Enter [yellow]Product ID[/]:");
            string category = AnsiConsole.Ask<string>("Enter [yellow]Category[/]:");
            decimal price = AnsiConsole.Ask<decimal>("Enter [yellow]Price[/]:");

            var product = new Product(name, id, category, price);


            int iterations = 100_000;
            var stopWatch1 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string result = Serializer.Serialize(product);
            }
            stopWatch1.Stop();
            Console.WriteLine($"Reflection: {stopWatch1.ElapsedMilliseconds} ms");

            var emitSerializer = EmitSerializer.CreateSerializer<Product>();
            var stopWatch2 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string result = emitSerializer(product);
            }
            stopWatch2.Stop();
            Console.WriteLine($"Emit: {stopWatch2.ElapsedMilliseconds} ms");

            Console.WriteLine("\nSample Output:\n");
            Console.WriteLine(emitSerializer(product));
        }
    }
}
