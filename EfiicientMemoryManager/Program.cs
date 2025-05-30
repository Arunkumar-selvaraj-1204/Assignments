using EfficientMemoryManager.Task_2;
namespace EfficientMemoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EfficientArrayHandler task2 = new EfficientArrayHandler();
            task2.GetValuesFromUser();
            task2.Allocate();
        }
    }
}
