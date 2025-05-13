namespace ErrorHandling
{
    internal class Utils
    {

        /// <summary>
        /// Pauses the console until the user press a key.
        /// </summary>
        public static void PressKeyToContinue()
        {
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
