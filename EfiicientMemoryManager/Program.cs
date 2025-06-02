using EfficientMemoryManager.Task_2;
namespace EfficientMemoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var efficientArrayHandler = new EfficientArrayHandler();
            efficientArrayHandler.GetValuesFromUser();
            efficientArrayHandler.Allocate();
        }
    }
}
