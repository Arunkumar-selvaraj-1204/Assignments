using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task1
{
    /// <summary>
    /// Class to implement task1
    /// </summary>
    public class BookStore
    {
        /// <summary>
        /// List to store titles
        /// </summary>
        public List<string> TitleList { get; set; }

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public BookStore()
        {
            TitleList = new List<string>();
        }

        /// <summary>
        /// Invoke all the methods
        /// </summary>
        public void ExecuteListOperations()
        {
            Console.WriteLine("List implementation");
            Console.WriteLine("______________________");

            //Add Books
            int numberOfBooks = 5;
            Console.WriteLine("Enter five book titles to add :");
            for (int i = 0; i < numberOfBooks; i++)
            {
                AddBook(Console.ReadLine(), TitleList);
            }
            Console.WriteLine("Titles added Successfully !");
            Console.WriteLine("______________________");

            //Remove Book
            Console.WriteLine("Enter the Book title to remove :");
            string titleToRemove = Console.ReadLine();
            if (RemoveBook(titleToRemove, TitleList))
            {
                Console.WriteLine("Removed successfully !");
            }
            else
            {
                Console.WriteLine("Title not found to remove");
            }
            Console.WriteLine("______________________");

            //Check Book title
            Console.WriteLine("Enter the title to check :");
            string titleTocheck = Console.ReadLine();
            if (CheckBookTitle(titleTocheck, TitleList))
            {
                Console.WriteLine($"Title {titleTocheck} present in the _list ");
            }
            else
            {
                Console.WriteLine("Title not found in the _list");
            }
            Console.WriteLine("______________________");

            DisplayAllTitle(TitleList);
            Console.WriteLine("***********************");
        }

        private void AddBook(string BookTitle, List<string> bookList)
        {
            bookList.Add(BookTitle);

        }

        private bool RemoveBook(string titleToRemove, List<string> bookList)
        {
            
            bool result = bookList.Remove(titleToRemove);
            return result;
        }

        private bool CheckBookTitle(string titleTocheck, List<string> bookList)
        {
            
            bool result = bookList.Contains(titleTocheck);
           return result;
        }

        private void DisplayAllTitle(List<string> bookList)
        {
            Console.WriteLine("All Titles :");
            Console.WriteLine("______________________");
            foreach (var title in bookList)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine("______________________");
        }
    }
}
