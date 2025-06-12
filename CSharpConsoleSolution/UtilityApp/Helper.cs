namespace UtilityApp
{
    /// <summary>
    /// Helper to get values from the user
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Gets string from user
        /// </summary>
        /// <returns>Returns string</returns>
        public static string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets int from user
        /// </summary>
        /// <returns>Returns int</returns>
        public static int GetInt()
        {
            string input = Console.ReadLine();
            int value;
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}