﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task4
{
    /// <summary>
    /// Class to implement task4
    /// </summary>
    public class StudentGradeSystem
    {
        /// <summary>
        /// Dictionary to store string ,int as key value pair
        /// </summary>
        public Dictionary<string, int> StudentDictionary { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public StudentGradeSystem()
        {
            StudentDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteDictionaryOperations()
        {
            Console.WriteLine("Dictionary implementation");
            Console.WriteLine("______________________");
            Console.WriteLine("Enter details of five students: ");
            AddStudents();
            RemoveStudent();
            DisplayStudents();
            Console.WriteLine("***********************");
        }

        private void AddStudents()
        {
            int numberOfStudents = 5;
            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.Write("Enter the name of student " + (i + 1) + ": ");
                string name = Console.ReadLine();
                Console.Write("Enter the grade of student " + (i + 1) + ": ");
                int grade = int.Parse(Console.ReadLine());
                StudentDictionary.Add(name, grade);
                Console.WriteLine("______________________");
            }
        }

        private void RemoveStudent()
        {
            Console.WriteLine("Enter the name of student to remove: ");
            string name = Console.ReadLine();
            if (StudentDictionary.ContainsKey(name))
            {
                StudentDictionary.Remove(name);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Console.WriteLine("______________________");
        }

        private void DisplayStudents()
        {
            Console.WriteLine("Students in the dictionary: ");
            Console.WriteLine("______________________");
            foreach (KeyValuePair<string, int> student in StudentDictionary)
            {
                Console.WriteLine(student.Key + " - " + student.Value);
            }
            Console.WriteLine("______________________");
        }
    }
}
