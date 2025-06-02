using System;
using ValueAndReferenceTypes;
namespace GarbageCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------- Memory Management in C# --------");
            Console.WriteLine("-------- Triggered Garbage Collection --------");
            var people = new List<Person>();

            for (int outerCount = 0; outerCount < 10; outerCount++)
            {
                Console.WriteLine($"Memory before object creation: {GC.GetTotalMemory(false)} bytes");
                for (int innerCount = 0; innerCount < 1000; innerCount++)
                {
                    var person = new Person();
                    person.Age = innerCount;
                    IncrementAge(person);
                    people.Add(person);
                    person = null;
                }
                Console.WriteLine($"Memory after object creation: {GC.GetTotalMemory(false)} bytes");
                GC.Collect();
                Console.WriteLine($"Memory after garbage collection: {GC.GetTotalMemory(false)} bytes\n");
            }
        }

        /// <summary>
        /// Increments the age of the person
        /// </summary>
        /// <param name="person"> Represents the particular person </param>
        public static void IncrementAge(Person person)
        {
            person.Age++;
        }
    }
}
