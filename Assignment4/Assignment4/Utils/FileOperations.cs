using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Utils
{
    internal class FileOperations
    {
        public static void WriteListToFile(string data, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public static string ReadListFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    return data;
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                    File.Create(filePath).Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return null;
            }
        }
    }
}
