namespace DynamicMockerHelper
{
    public class DynamicMockerHelper : ICalculator
    {
        public string Name => "Mock Calculator";

        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
