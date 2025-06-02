namespace FilesAndStreams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Large text file is creating ...");
            FileDataHandler.CreateLargeFile(1, "largeFile.txt");
            Console.WriteLine("File created successfully!!!");
            Console.WriteLine("File reading started");
            Console.WriteLine("TimeTaken: " + FileDataHandler.ConvertToUpperCaseUsingChunks("largeFile.txt", "upperCaseFile.txt"));
        }
    }
}
