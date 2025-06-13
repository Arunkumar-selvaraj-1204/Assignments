using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class ArunPlugin : IPlugins
    {
        public string Name => "Arun";

        public void PrintName()
        {
            Console.WriteLine($"The owner is {Name}");
        }
    }
}
