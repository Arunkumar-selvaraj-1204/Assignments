using System;

namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += PrintMessage;

            Console.Write("Enter a message to display: ");
            string message = Console.ReadLine();
            notifier.TriggerEvent(message);
        }

        private static void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
