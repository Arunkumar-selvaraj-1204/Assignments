using InefficientMemoryManager.Task_1;

namespace InefficientMemoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var memoryEater = new MemoryEater();
            memoryEater.Allocate();
        }
    }
}
