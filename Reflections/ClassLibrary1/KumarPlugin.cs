using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class KumarPlugin : IPlugins
    {
        public string Name => "Kumar";

        public void PrintName()
        {
            Console.WriteLine($"The owner is {Name}");
        }
    }
}
