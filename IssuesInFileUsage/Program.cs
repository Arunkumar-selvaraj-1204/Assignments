using System;
using System.IO;
using System.Text;

namespace IssuesInFileUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "testText.txt";
            string data = "This is some test data";

            Console.WriteLine("=== Inefficient File Write and Read ===");
            InefficientFileWriteAndRead(path, data);

            Console.WriteLine("\n=== Optimized File Write and Read ===");
            OptimizedFileWriteAndRead(path, data);

            Console.ReadLine();
        }

        static void InefficientFileWriteAndRead(string path, string data)
        {
            // Write using MemoryStream unnecessarily
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            // Read using overly large buffer and inefficient printing
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void OptimizedFileWriteAndRead(string path, string data)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }

            // Read the file using exact-sized buffer and convert directly to string
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] readBuffer = new byte[fileStream.Length];
                int bytesRead = fileStream.Read(readBuffer, 0, readBuffer.Length);
                string result = Encoding.ASCII.GetString(readBuffer, 0, bytesRead);
                Console.WriteLine(result);
            }
        }
    }
}
