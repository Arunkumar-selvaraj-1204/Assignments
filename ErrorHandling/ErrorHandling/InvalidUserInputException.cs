namespace ErrorHandling
{
    internal class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message)
        : base(message) { }
    }
}
