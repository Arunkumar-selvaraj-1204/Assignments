namespace DynamicTypeBuilder
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("----Dynamic type builder----");
            Console.WriteLine("This application will build a dynamic type with a property in the assembly and its value");
            var dynamicType = CreateDynamicType();
            var instance = Activator.CreateInstance(dynamicType);
            var valueProp = dynamicType.GetProperty("Value");
            var printMethod = dynamicType.GetMethod("PrintValue");

            Console.Write("Original value from dynamic object: ");
            printMethod.Invoke(instance, null);
            int userValue = GetUserInput();
            valueProp.SetValue(instance, userValue);
            Console.Write("Value from dynamic object: ");
            printMethod.Invoke(instance, null);
        }

        static Type CreateDynamicType()
        {
            var assemblyName = new AssemblyName("UserAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("UserModule");

            var typeBuilder = moduleBuilder.DefineType("MyDynamicClass", TypeAttributes.Public);

            var fieldBuilder = typeBuilder.DefineField("_value", typeof(int), FieldAttributes.Private);

            var (getMethod, setMethod) = DefineProperty(typeBuilder, fieldBuilder);

            DefinePrintMethod(typeBuilder, getMethod);

            return typeBuilder.CreateType();
        }

        static (MethodBuilder getMethod, MethodBuilder setMethod) DefineProperty(TypeBuilder typeBuilder, FieldBuilder fieldBuilder)
        {
            var propertyBuilder = typeBuilder.DefineProperty("Value", PropertyAttributes.HasDefault, typeof(int), null);

            var getMethod = typeBuilder.DefineMethod("get_Value",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                typeof(int), Type.EmptyTypes);

            var getIL = getMethod.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getIL.Emit(OpCodes.Ret);

            var setMethod = typeBuilder.DefineMethod("set_Value",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                null, new Type[] { typeof(int) });

            var setIL = setMethod.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, fieldBuilder);
            setIL.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethod);
            propertyBuilder.SetSetMethod(setMethod);

            return (getMethod, setMethod);
        }

        static void DefinePrintMethod(TypeBuilder typeBuilder, MethodBuilder getMethod)
        {
            var printMethod = typeBuilder.DefineMethod("PrintValue",
                MethodAttributes.Public, null, Type.EmptyTypes);

            var il = printMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, getMethod);
            il.Emit(OpCodes.Box, typeof(int));
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(object) }));
            il.Emit(OpCodes.Ret);
        }

        static int GetUserInput()
        {
            while (true)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

}
