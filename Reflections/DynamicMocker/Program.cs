using DynamicMockerHelper;

namespace DynamicMocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mock = (ICalculator)DynamicMockBuilder.CreateMock(typeof(ICalculator));
            Console.WriteLine(mock.Name);
            Console.WriteLine(mock.Add(2, 3));
            

        }
    }
}
