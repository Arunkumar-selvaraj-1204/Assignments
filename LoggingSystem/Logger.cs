using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace LoggingSystem
{
    public class Logger
    {
        private static string _logFilePath;

        public Logger(string filePath) 
        {
            _logFilePath = filePath;
        }
        public void LogErrorInefficiently(string errorMessage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
        public async void LogErrorEfficiently(string errorMessage)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(errorMessage);
            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
            {
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        public async Task LogErrorThreadSafe(string errorMessage)
        {
            var semaphoreSlim = new SemaphoreSlim(1);
            byte[] bytes = Encoding.UTF8.GetBytes(errorMessage);
            await semaphoreSlim.WaitAsync();
            try
            {
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
                {
                    await fileStream.WriteAsync(bytes, 0, bytes.Length);
                }
            }
            finally 
            {
                semaphoreSlim.Release();
            }
            
        }

        public async Task LogErrorInUserSpecificFile(string userId, string errorMessage)
        {
            string filePath = $"{userId}Error.log";
            byte[] bytes = Encoding.UTF8.GetBytes(errorMessage);
            using(FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
