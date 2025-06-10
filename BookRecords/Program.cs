namespace BookRecords
{
    /// <summary>
    /// Defines a record for Book with Title, Author, and ISBN.
    /// </summary>
    public record Book(string Title, string Author, string ISBN);

    class Program
    {
        static void Main()
        {
            var books = new Book[3];
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"\nEnter details for Book {i + 1}:");

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author: ");
                string author = Console.ReadLine();

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                books[i] = new Book(title, author, isbn);
            }

            Console.WriteLine("\n--- Book Details ---");
            foreach (var book in books)
            {
                DisplayBook(book);
            }

            // Demonstrate value equality
            var bookA = new Book("C# in Depth", "Jon Skeet", "9781617294532");
            var bookB = new Book("C# in Depth", "Jon Skeet", "9781617294532");

            Console.WriteLine("\n--- Value Equality Demo ---");
            Console.WriteLine($"BookA: {bookA}");
            Console.WriteLine($"BookB: {bookB}");
            Console.WriteLine($"BookA == BookB: {bookA == bookB}");

            // Show immutability
            Console.WriteLine("\n--- Immutability Demo ---");
            // bookA.Title = "New Title"; // Uncommenting this line will result in an error because records are immutable.

            Console.WriteLine("Records are immutable. You can't change the property after creation.");

            // Demonstrate mutation using 'with'
            Console.WriteLine("--------------------- \nChange the title of book A \nEnter book name: ");
            var updatedBookA = bookA with { Title = Console.ReadLine() };
            Console.WriteLine("\n--- Non-destructive Mutation Demo ---");
            Console.WriteLine($"Original:    {bookA}");
            Console.WriteLine($"After 'with': {updatedBookA}");

        }

        /// <summary>
        /// Displays a Book's properties using deconstruction.
        /// </summary>
        /// <param name="book">The Book record to display.</param>
        static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"Title: {title}, Author: {author}, ISBN: {isbn}");
        }
        
    }
}
