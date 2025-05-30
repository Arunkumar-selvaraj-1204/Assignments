using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task2
{
    /// <summary>
    /// Class to implement task2
    /// </summary>
    public class Stacks
    {
        /// <summary>
        /// Stack to store character
        /// </summary>
        public Stack<char> CharStack { get; set; }

        /// <summary>
        /// String to reverse
        /// </summary>
        public string StringToReverse { get; set; }

        /// <summary>
        /// String in reversed order
        /// </summary>
        public string ReversedString { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Stacks()
        {
            CharStack = new Stack<char>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteStackOperations()
        {
            Console.WriteLine("Stack implementation");
            Console.WriteLine("______________________");
            Console.WriteLine("Enter a string to reverse: ");
            StringToReverse = Console.ReadLine();
            AddCharToStack(StringToReverse, CharStack);
            Console.WriteLine("String reverse: ");
            ReversedString = PopAndAppendChar(CharStack);
            DisplayResult(StringToReverse, ReversedString);
            Console.WriteLine("***********************");
        }

        private void AddCharToStack(string stringToReverse, Stack<char> charStack)
        {
            foreach (char c in stringToReverse)
            {
                charStack.Push(c);
            }
        }

        private string PopAndAppendChar(Stack<char> charStack)
        {
            string reversedString = "";
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }
            return reversedString;
        }

        private void DisplayResult(string stringToReverse, string reversedString)
        {
            Console.WriteLine("Original string : " + stringToReverse);
            Console.WriteLine("Reversed string : " + reversedString);
            Console.WriteLine("___________________________________");
        }
    }
}
