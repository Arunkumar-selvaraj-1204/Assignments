namespace IDisposableDemo

{

    public class Program

    {

        public static void Main(string[] args)

        {

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("-------- Memory Management in C# --------");

            Console.WriteLine("-------- Handling File Operations --------");

            string filename = "file.txt";

            string text = "Text written to the file successfully!!";

            // Print the count down to complete writing

            Console.WriteLine("Starting to write text to a file...");

            Console.Write("Count down to complete writing - ");

            for (int time = 3; time > 0; time--)

            {

                Thread.Sleep(1000);

                Console.Write($"{time} ");

            }

            // Create an instance of file writer and releases it after its use

            using (var fileWriter = new FileWriter(filename))

            {

                fileWriter.Write(text);

            }

            // Display success message for writing

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nFile writing completed successfully!!");

            Console.ForegroundColor = ConsoleColor.White;

            // Print the count down to complete reading

            Console.WriteLine("\nStarting to read text from a file...");

            Console.Write("Count down to complete reading - ");

            for (int time = 3; time > 0; time--)

            {

                Thread.Sleep(1000);

                Console.Write($"{time} ");

            }

            // Display message for the contents read from file

            Console.WriteLine("\nContents of the file are as follows: ");

            Console.WriteLine("-------- Contents read from the file --------");

            // Read the content from the file to ensure it was released properly

            var streamReader = new StreamReader(filename);

            Console.WriteLine(streamReader.ReadToEnd());

            // Display success message for reading

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("File reading completed successfully!!");

            Console.ForegroundColor = ConsoleColor.White;

        }

    }

}
