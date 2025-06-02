using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InefficientMemoryManager.Task_1
{
    public class MemoryEater
    {
        List<int[]> memoryAllocator = new List<int[]>();

        public void Allocate()
        {
            while (true)
            {
                memoryAllocator.Add(new int[1000]);
                Thread.Sleep(100);
            }
        }
    }
}
