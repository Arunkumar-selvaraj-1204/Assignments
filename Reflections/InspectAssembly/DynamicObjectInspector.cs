using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InspectAssembly
{
    internal class DynamicObjectInspector
    {
        public Type instanceType;
        public PropertyInfo[] propertyInfo;
        public object instanceObject;
        public DynamicObjectInspector(object assemblyObject) 
        { 
            var assembly = assemblyObject as Assembly;
            instanceType = assembly.GetType("ReflectionHelper.Helper");
            instanceObject = Activator.CreateInstance(instanceType);
            propertyInfo = instanceType.GetProperties();
        }

        public void DisplayProerties()
        {
            foreach (PropertyInfo property in propertyInfo)
            {
                Console.WriteLine(property.Name + " - " + property.GetValue(instanceObject));
            }
        }

        public bool ChangePropertyValue(string propertyName)
        {
            var property = instanceType.GetProperty(propertyName);
            if (property != null)
            {
                var newValue = GetNewValue(propertyName);
                property.SetValue(instanceObject, newValue, null);
                return true;
            }
            else
            {
                return false;
            }
        }
        private static dynamic GetNewValue(string propertyName)
        {
            Console.Write("Enter new value: ");
            if (propertyName == "age")
            {
                return GetNumber();
            }
            else
            {
                return Console.ReadLine();
            }
        }
        private static int GetNumber()
        {
            Console.Write("Enter a number: ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Enter valid integer: ");
            }
            return result;
        }
    }

}
