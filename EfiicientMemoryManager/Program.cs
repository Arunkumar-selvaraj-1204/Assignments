using EfficientMemoryManager.Task_2;
namespace EfficientMemoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task2 task2 = new Task2();
            task2.GetValuesFromUser();
            task2.Allocate();
        }
    }
}
