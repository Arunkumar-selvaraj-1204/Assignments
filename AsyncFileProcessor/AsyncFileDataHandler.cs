﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace AsyncFileProcessor
{
    internal class AsyncFileDataHandler
    {
        private const int ChunkSize = 4 * 1024;

        public async Task<long> ConvertToUpperCaseAsync(string sourcePath, string destinationPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                using FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize: ChunkSize, useAsync: true);
                using FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: ChunkSize, useAsync: true);
                await PerformConvertionToUpperCase(sourceStream, destinationStream);
            }
            catch
            {
                AnsiConsole.MarkupLine("[red]More than one user trying to access same file. So the program crashed");
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public async Task ProcessMultipleFilesAsync(List<(string sourcePath, string destinationPath)> filePairs)
        {
            List<Task<long>> processingTasks = new List<Task<long>>();

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

        private static async Task PerformConvertionToUpperCase(FileStream sourceStream, FileStream destinationStream)
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
