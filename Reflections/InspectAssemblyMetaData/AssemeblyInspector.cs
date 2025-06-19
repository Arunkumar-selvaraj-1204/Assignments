using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InspectAssemblyMetaData
{
    public class AssemeblyInspector
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("InspectAssemblyMetaData.dll");
            Console.WriteLine(assembly.GetType().GetProperties()[0]);
        }
    }
}
