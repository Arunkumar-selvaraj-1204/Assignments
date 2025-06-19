using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMocker
{
    public class DynamicMockBuilder
    {
        public static object CreateMock(Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Only interfaces can be mocked.");

            var assemblyName = new AssemblyName("DynamicMocksAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            string typeName = $"Mock_{interfaceType.Name}";
            var typeBuilder = moduleBuilder.DefineType(typeName,
                TypeAttributes.Public | TypeAttributes.Class, null, new[] { interfaceType });

            foreach (var method in interfaceType.GetMethods())
            {
                if (method.IsSpecialName) continue;

                var paramTypes = Array.ConvertAll(method.GetParameters(), p => p.ParameterType);

                var methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    paramTypes
                );

                var il = methodBuilder.GetILGenerator();

                if (method.ReturnType == typeof(void))
                    il.Emit(OpCodes.Ret);
                else if (method.ReturnType.IsValueType)
                {
                    var local = il.DeclareLocal(method.ReturnType);
                    il.Emit(OpCodes.Ldloca_S, local);
                    il.Emit(OpCodes.Initobj, method.ReturnType);
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ret);
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ret);
                }

                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }

            foreach (var prop in interfaceType.GetProperties())
            {
                var field = typeBuilder.DefineField($"_{prop.Name.ToLower()}", prop.PropertyType, FieldAttributes.Private);

                var propBuilder = typeBuilder.DefineProperty(prop.Name, PropertyAttributes.None, prop.PropertyType, null);

                // Define getter
                if (prop.GetGetMethod() != null)
                {
                    var getMethod = typeBuilder.DefineMethod($"get_{prop.Name}",
                        MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                        prop.PropertyType, Type.EmptyTypes);

                    var il = getMethod.GetILGenerator();

                    if (prop.PropertyType.IsValueType)
                    {
                        var local = il.DeclareLocal(prop.PropertyType);
                        il.Emit(OpCodes.Ldloca_S, local);
                        il.Emit(OpCodes.Initobj, prop.PropertyType);
                        il.Emit(OpCodes.Ldloc_0);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldnull);
                    }

                    il.Emit(OpCodes.Ret);
                    typeBuilder.DefineMethodOverride(getMethod, prop.GetGetMethod());
                    propBuilder.SetGetMethod(getMethod);
                }
            }

            var mockType = typeBuilder.CreateType();
            return Activator.CreateInstance(mockType);
        }
    }
}
