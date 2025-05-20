using MemoryProfiling.Task1;
namespace MemoryProfiling
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