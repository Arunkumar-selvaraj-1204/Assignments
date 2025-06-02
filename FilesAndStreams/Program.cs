namespace FilesAndStreams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileDataHandler fileHandler = new FileDataHandler();
            Console.WriteLine("Large text file is creating ...");
            fileHandler.CreateLargeFile(1, "largeFile.txt");
            Console.WriteLine("File created successfully!!!");

            Console.WriteLine("File reading started for chunks method");
            Console.WriteLine("TimeTaken to read file as chunks: " 
                + (double) fileHandler.ReadFileUsingFileStream("largeFile.txt")/ 1000 + "sec");

            Console.WriteLine("File reading started for bufferStream method");
            Console.WriteLine("TimeTaken to read file using BufferStream: " 
                + (double)fileHandler.ReadFileUsingBufferedStream("largeFile.txt")/ 1000 + "sec");
            Console.WriteLine("Converting text to uppercase using File stream");
            Console.WriteLine("TimeTaken to convert strings to uppercase using chunks: " 
                + (double)fileHandler.ConvertToUpperCaseUsingChunks("largeFile.txt", "uppercase.txt") / 1000 + "sec");
            Console.WriteLine("Converting text to uppercase using Buffered stream");
            Console.WriteLine("TimeTaken to convert strings to uppercase using BufferedStream: "
                + (double)fileHandler.ConvertToUpperCaseUsingBufferStream("largeFile.txt", "uppercase.txt") / 1000 + "sec");
            Console.WriteLine("Converting text to uppercase using Memory stream");
            Console.WriteLine("TimeTaken to convert strings to uppercase using Memory Stream: "
                + (double)fileHandler.ConvertToUpperCaseUsingMemoryStream("largeFile.txt", "uppercase.txt") / 1000 + "sec");

        }
    }
}
