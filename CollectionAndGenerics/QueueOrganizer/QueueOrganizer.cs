using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task3
{
    /// <summary>
    /// Class to implement task3
    /// </summary>
    public class QueueOrganizer
    {
        /// <summary>
        /// Queue stores people
        /// </summary>
        public Queue<string> PeopleQueue { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public QueueOrganizer()
        {
            PeopleQueue = new Queue<string>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteQueueOperations()
        {
            Console.WriteLine("Queue implementation");
            Console.WriteLine("______________________");
            AddPeopleToQueue();
            ServePeople();
            DisplayPeopleInQueue();
            Console.WriteLine("***********************");
        }

        private void AddPeopleToQueue()
        {
            Console.WriteLine("Enter the number of people to add to the queue: ");
            int numberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the values :");
            Console.WriteLine("______________________");
            for (int i = 0; i < numberOfPeople; i++)
            {
                Console.Write("Enter the name of person " + (i + 1) + ": ");
                string name = Console.ReadLine();
                PeopleQueue.Enqueue(name);
            }
            Console.WriteLine("______________________");
        }

        private void ServePeople()
        {
            if (PeopleQueue.Count == 0)
            {
                Console.WriteLine("No people in the queue.");
                return;
            }
            else
            {
                Console.WriteLine("Enter the number of people to serve: ");
                int numberOfPeople = GetInt();
                while (numberOfPeople > PeopleQueue.Count)
                {
                    Console.WriteLine($"People in queue is {PeopleQueue.Count}");
                    Console.WriteLine("Enter the number of people to serve: ");
                    numberOfPeople = GetInt();
                }
                for (int i = 0; i < numberOfPeople; i++)
                {
                    Console.WriteLine($"Served {PeopleQueue.Dequeue()} from the queue :-) ");
                }
            }
            Console.WriteLine("______________________");
        }

        private void DisplayPeopleInQueue()
        {
            Console.WriteLine("People in the queue: ");

            if(PeopleQueue.Count == 0)
            {
                Console.WriteLine("Queue is empty");
            }
            foreach (string person in PeopleQueue)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("______________________");
        }

        /// <summary>
        /// Gets int from user
        /// </summary>
        /// <returns>Returns int</returns>
        public static int GetInt()
        {
            string input = Console.ReadLine();
            int value;
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
