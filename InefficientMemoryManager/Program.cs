using InefficientMemoryManager.Task_1;

namespace InefficientMemoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryEater task1 = new MemoryEater();
            task1.Allocate();
        }
    }
}
