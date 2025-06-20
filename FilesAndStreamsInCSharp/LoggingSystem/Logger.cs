﻿using System.Text;

namespace LoggingSystem
{
    /// <summary>
    /// Provides various methods for logging error messages to files using different techniques.
    /// </summary>
    public class Logger
    {
        private static string _logFilePath;

        /// <summary>
        /// Initializes the logger with a log file path.
        /// </summary>
        /// <param name="filePath">Path to the log file.</param>
        public Logger(string filePath)
        {
            _logFilePath = filePath;
        }

        /// <summary>
        /// Logs an error inefficiently using a MemoryStream.
        /// </summary>
        /// <param name="errorMessage">Error message to log.</param>
        public void LogErrorInefficiently(string errorMessage)
        {
            using (var memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);
                using (var fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }

        /// <summary>
        /// Logs an error efficiently using async FileStream.
        /// </summary>
        /// <param name="errorMessage">Error message to log.</param>
        public async void LogErrorEfficientlyAsync(string errorMessage)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(errorMessage);
            using (var fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
            {
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Logs an error in a thread-safe way using SemaphoreSlim.
        /// </summary>
        /// <param name="errorMessage">Error message to log.</param>
        /// <returns>A task representing the async operation.</returns>
        public async Task LogAsyncWithThreadSafety(string errorMessage)
        {
            var semaphoreSlim = new SemaphoreSlim(1);
            byte[] bytes = Encoding.UTF8.GetBytes(errorMessage);
            await semaphoreSlim.WaitAsync();
            try
            {
                using (var fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
                {
                    await fileStream.WriteAsync(bytes, 0, bytes.Length);
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        /// <summary>
        /// Logs an error to a user-specific file asynchronously.
        /// </summary>
        /// <param name="userId">User ID for the log file.</param>
        /// <param name="errorMessage">Error message to log.</param>
        /// <returns>A task representing the async operation.</returns>
        public async Task LogErrorAsyncInUserSpecificFile(string userId, string errorMessage)
        {
            string filePath = $"{userId}Error.log";
            byte[] bytes = Encoding.UTF8.GetBytes(errorMessage);
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}