namespace AsyncFileProcessor
{
        internal class Program
        {
            static async Task Main(string[] args)
            {
                AsyncFileDataHandler handler = new AsyncFileDataHandler();

                var filesToProcess = new List<(string, string)>
            {
                ("file1.txt", "file1_output.txt"),
                ("file2.txt", "file2_output.txt"),
                ("file3.txt", "file3_output.txt")
            };

                Console.WriteLine("Starting asynchronous file processing...");
                await handler.ProcessMultipleFilesAsync(filesToProcess);
                Console.WriteLine("All files processed.");
            }
        
    }
}
