using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndStreams
{
    internal class FileDataHandler
    {
        public static void CreateLargeFile(long size, string filePath)
        {
            long fileSize = size * 1024 * 1024 * 1024;
            string textToWrite = "Hello world!\n";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.ASCII))
            {
                long totalWritten = 0;
                while (totalWritten < fileSize)
                {
                    writer.Write(textToWrite);
                    totalWritten += textToWrite.Length;
                }
            }
        }

        public static long ConvertToUpperCaseUsingChunks(string sourcePath, string destinationPath )
        {
            using (FileStream fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (FileStream fileStreamToWrite = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fileStreamToWrite, Encoding.ASCII))
            using (StreamReader reader = new StreamReader(fileStreamToRead))
            {
                int chunkSize = 4 * 1024;
                char[] buffer = new char[chunkSize];
                int bytesRead = 0;
                int chunkNumber = 1;

                Stopwatch sw = Stopwatch.StartNew();
                
                do{
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string chunk = new string(buffer, 0, bytesRead);
                    writer.Write(chunk.ToUpper());
                } while (bytesRead > 0) ;
                    sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }

        
    }
}
