﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilesAndStreams
{
    /// <summary>
    /// Handles file creation, reading, and upper-case conversions using various stream techniques.
    /// </summary>
    internal class FileDataHandler
    {
        /// <summary>
        /// Creates a large file of specified size with repeated user input.
        /// </summary>
        /// <param name="size">Size in GB.</param>
        /// <param name="filePath">File path to create.</param>
        public void CreateLargeFile(long size, string filePath)
        {
            long fileSize = size * 1024 * 1024 * 1024;
            string textToWrite = GetTextFromUser();
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(fileStream, Encoding.ASCII))
            {
                long totalWritten = 0;
                while (totalWritten < fileSize)
                {
                    writer.Write(textToWrite);
                    totalWritten += textToWrite.Length;
                }
            }
        }

        /// <summary>
        /// Reads a file in chunks using FileStream and StreamReader.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ReadFileUsingFileStream(string sourcePath)
        {
            using (var fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(fileStreamToRead))
            {
                int chunkSize = 4 * 1024;
                char[] buffer = new char[chunkSize];
                int bytesRead = 0;

                var stopWatch = Stopwatch.StartNew();

                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string chunk = new string(buffer, 0, bytesRead);
                } while (bytesRead > 0);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Reads a file in chunks using BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ReadFileUsingBufferedStream(string sourcePath)
        {
            using (var fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var bufferedInput = new BufferedStream(fileStreamToRead))
            using (var reader = new StreamReader(bufferedInput))
            {
                int chunkSize = 4 * 1024;
                char[] buffer = new char[chunkSize];
                int bytesRead = 0;

                var stopWatch = Stopwatch.StartNew();

                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string chunk = new string(buffer, 0, bytesRead);
                } while (bytesRead > 0);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Converts file content to upper case in chunks and writes to destination.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <param name="destinationPath">Destination file path.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ConvertToUpperCaseUsingChunks(string sourcePath, string destinationPath)
        {
            using (var fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var fileStreamToWrite = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(fileStreamToWrite, Encoding.ASCII))
            using (var reader = new StreamReader(fileStreamToRead))
            {
                int chunkSize = 4 * 1024;
                char[] buffer = new char[chunkSize];
                int bytesRead = 0;

                var stopWatch = Stopwatch.StartNew();

                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string chunk = new string(buffer, 0, bytesRead);
                    writer.Write(chunk.ToUpper());
                } while (bytesRead > 0);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Converts file content to upper case using BufferedStream and writes to destination.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <param name="destinationPath">Destination file path.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ConvertToUpperCaseUsingBufferStream(string sourcePath, string destinationPath)
        {
            using (var fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var bufferedInput = new BufferedStream(fileStreamToRead))
            using (var fileStreamToWrite = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var bufferedOutput = new BufferedStream(fileStreamToWrite))
            using (var writer = new StreamWriter(bufferedOutput, Encoding.ASCII))
            using (var reader = new StreamReader(bufferedInput))
            {
                int chunkSize = 4 * 1024;
                char[] buffer = new char[chunkSize];
                int bytesRead = 0;

                var stopWatch = Stopwatch.StartNew();

                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    string chunk = new string(buffer, 0, bytesRead);
                    writer.Write(chunk.ToUpper());
                } while (bytesRead > 0);
                stopWatch.Stop();
                return stopWatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Converts file content to upper case using MemoryStream as intermediate buffer.
        /// </summary>
        /// <param name="sourcePath">Source file path.</param>
        /// <param name="destinationPath">Destination file path.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ConvertToUpperCaseUsingMemoryStream(string sourcePath, string destinationPath)
        {
            using (var fileStreamToRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var fileStreamToWrite = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[(4 * 1024)];
                int bytesRead;

                var stopwatch = Stopwatch.StartNew();
                while ((bytesRead = fileStreamToRead.Read(buffer, 0, buffer.Length)) > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                        memoryStream.Position = 0;
                        byte[] processedBytes = new byte[bytesRead];
                        int processedLength = memoryStream.Read(processedBytes, 0, bytesRead);

                        string chunkString = Encoding.ASCII.GetString(processedBytes, 0, processedLength);
                        string upperChunkString = chunkString.ToUpper();
                        byte[] upperChunkBytes = Encoding.ASCII.GetBytes(upperChunkString);

                        fileStreamToWrite.Write(upperChunkBytes, 0, upperChunkBytes.Length);
                    }
                }
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Gets a string from the user to write in the file.
        /// </summary>
        /// <returns>User input string.</returns>
        private static string GetTextFromUser()
        {
            Console.Write("Enter a string to write in the file: ");
            return Console.ReadLine();
        }
    }
}