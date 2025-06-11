using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InspectAssembly
{
    public class DynamicMethodInvoker
    {
        public Type instanceType;
        public MethodInfo methodInfo;
        public object instanceObject;
        public DynamicMethodInvoker(object assemblyObject) 
        {
            Assembly assembly = assemblyObject as Assembly;
            instanceType = assembly.GetType("ReflectionHelper.Helper");
            instanceObject = Activator.CreateInstance(instanceType);
            methodInfo = instanceType.GetMethod("Add");
        }
        public dynamic AddTwoNumber(dynamic firstNumber, dynamic secondNumber)
        {
            return methodInfo.Invoke(instanceObject, new object[] { firstNumber, secondNumber });
        }
    }
}
