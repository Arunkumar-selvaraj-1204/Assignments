using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMockerHelper
{
    public interface ICalculator
    {
        string Name { get; }
        int Add(int value1, int value2);
    }
}
