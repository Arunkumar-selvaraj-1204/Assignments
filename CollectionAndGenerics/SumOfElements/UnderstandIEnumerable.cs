﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task6
{
    /// <summary>
    /// Class to understand IEnumerable
    /// </summary>
    public class UnderstandIEnumerable
    {
        private List<int> _list;
        private Stack<int> _stack;
        private Queue<int> _queue;

        public UnderstandIEnumerable()
        {
            _list = new List<int> { 1, 2, 3, 4, 5 };
            _stack = new Stack<int>();
            _queue = new Queue<int>();
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);
            _queue.Enqueue(6);
        }

        /// <summary>
        /// Invoke the flow
        /// </summary>
        public void ExecuteIEnumerableOperations()
        {
            Console.WriteLine("Understanding IEnumerable \n");
            Console.WriteLine("______________________");
            Console.WriteLine("Elements in list: ");
            foreach (var number in _list)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Sum of List is {SumOfElements(_list)}");
            Console.WriteLine("Elements in stack: ");
            foreach (var number in _stack)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Sum of Stack is {SumOfElements(_stack)}");
            Console.WriteLine("Elements in queue: ");
            foreach (var number in _queue)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Sum of Queue is {SumOfElements(_queue)}");
            Console.WriteLine("***********************");
        }

        /// <summary>
        /// Add all the elements
        /// </summary>
        /// <param name="elements">Elements to add</param>
        /// <returns>Returns the sum of the elements</returns>
        public int SumOfElements(IEnumerable<int> elements)
        {
            return elements.Sum(i => i);
        }
    }
}
