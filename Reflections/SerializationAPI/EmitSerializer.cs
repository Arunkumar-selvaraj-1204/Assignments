using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAPI
{
    internal class EmitSerializer
    {
        public static Func<T, string> CreateSerializer<T>()
        {
            Type type = typeof(T);
            DynamicMethod method = new DynamicMethod($"Serialize_{type}", typeof(string), new[] { type }, true);
            ILGenerator il = method.GetILGenerator();

            var sbCtor = typeof(StringBuilder).GetConstructor(Type.EmptyTypes);
            var sbAppendLine = typeof(StringBuilder).GetMethod("AppendLine", new[] { typeof(string) });
            var sbToString = typeof(StringBuilder).GetMethod("ToString", Type.EmptyTypes);
            var toStringMethod = typeof(Convert).GetMethod("ToString", new[] { typeof(object) });
            var concatMethod = typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) });

            LocalBuilder sb = il.DeclareLocal(typeof(StringBuilder));
            il.Emit(OpCodes.Newobj, sbCtor);
            il.Emit(OpCodes.Stloc, sb);

            il.Emit(OpCodes.Ldloc, sb);
            il.Emit(OpCodes.Ldstr, $"Type: {type}");
            il.Emit(OpCodes.Callvirt, sbAppendLine);
            il.Emit(OpCodes.Pop);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var getter = prop.GetGetMethod();
                if (getter == null) continue;

                il.Emit(OpCodes.Ldloc, sb);
                il.Emit(OpCodes.Ldstr, $"{prop.Name} = ");
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Callvirt, getter);
                if (prop.PropertyType.IsValueType)
                    il.Emit(OpCodes.Box, prop.PropertyType);
                il.Emit(OpCodes.Call, toStringMethod);
                il.Emit(OpCodes.Call, concatMethod);
                il.Emit(OpCodes.Callvirt, sbAppendLine);
                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ldloc, sb);
            il.Emit(OpCodes.Callvirt, sbToString);
            il.Emit(OpCodes.Ret);

            return (Func<T, string>)method.CreateDelegate(typeof(Func<T, string>));
        }
    }
}
