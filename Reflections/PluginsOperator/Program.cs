using System.Reflection;
using Plugins;

namespace PluginsOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pluginAssembly = Assembly.LoadFrom("../../../pluginsHelper.dll");
            foreach (var type in pluginAssembly.GetTypes())
            {
                if (type.GetInterface("IPlugins") != null && !type.IsInterface && !type.IsAbstract)
                {
                    var plugin = (IPlugins)Activator.CreateInstance(type);
                    Console.WriteLine($"Loaded Plugin: {plugin.Name}");
                    plugin.PrintName();
                }
            }
        }
    }
}
