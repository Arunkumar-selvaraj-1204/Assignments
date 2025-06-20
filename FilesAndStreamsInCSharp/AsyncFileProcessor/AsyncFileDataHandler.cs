﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace AsyncFileProcessor
{
    /// <summary>
    /// Handles asynchronous file processing.
    /// </summary>
    internal class AsyncFileDataHandler
    {
        // Buffer size for chunked reading and writing (4KB)
        private const int ChunkSize = 4 * 1024;

        /// <summary>
        /// Asynchronously converts the contents of a source file to upper case and writes it to a destination file.
        /// </summary>
        public async Task<long> ConvertToUpperCaseAsync(string sourcePath, string destinationPath)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                using var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize: ChunkSize, useAsync: true);
                using var destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: ChunkSize, useAsync: true);
                await PerformConvertionToUpperCaseAsync(sourceStream, destinationStream);
            }
            catch
            {
                AnsiConsole.MarkupLine("[red]More than one user trying to access same file. So the program crashed");
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Processes multiple file pairs concurrently, converting each source file to upper case.
        /// </summary>
        public async Task ProcessMultipleFilesAsync(List<(string sourcePath, string destinationPath)> filePairs)
        {
            var processingTasks = new List<Task<long>>();

            foreach (var (source, dest) in filePairs)
            {
                processingTasks.Add(ConvertToUpperCaseAsync(source, dest));
            }

            long[] durations = await Task.WhenAll(processingTasks);

            for (int i = 0; i < filePairs.Count; i++)
            {
                Console.WriteLine($"Processed file {filePairs[i].sourcePath} to {filePairs[i].destinationPath} in {durations[i]} ms");
            }
        }

        /// <summary>
        /// Reads from the source stream, converts each chunk to upper case, and writes to the destination stream asynchronously.
        /// </summary>
        private static async Task PerformConvertionToUpperCaseAsync(FileStream sourceStream, FileStream destinationStream)
        {
            byte[] buffer = new byte[ChunkSize];
            int bytesRead;

            while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string chunkString = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string upperChunkString = chunkString.ToUpper();
                byte[] upperChunkBytes = Encoding.ASCII.GetBytes(upperChunkString);
                await destinationStream.WriteAsync(upperChunkBytes, 0, upperChunkBytes.Length);
            }
        }
    }
}