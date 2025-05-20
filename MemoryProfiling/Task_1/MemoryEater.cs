using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryProfiling.Task_1
{
    public class MemoryEater
    {
        List<int[]> memalloc = new List<int[]>();

        public void Allocate()
        {
            while (true)
            {
                memalloc.Add(new int[1000]);
                Thread.Sleep(100);
            }
        }
    }
}
