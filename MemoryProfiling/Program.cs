using MemoryProfiling.Task_1;
using MemoryProfiling.Task_2;
namespace MemoryProfiling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater task1 = new MemoryEater();
            task1.Allocate();
            //Task2 task2 = new Task2();
            //task2.GetValuesFromUser();
            //task2.Allocate();
        }
    }

}