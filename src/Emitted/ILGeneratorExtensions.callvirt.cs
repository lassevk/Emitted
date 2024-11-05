using System;
using System.Reflection;
using System.Reflection.Emit;
// ReSharper disable InconsistentNaming

namespace Emitted;

public static partial class ILGeneratorExtensions
{
    public static ILGenerator callvirt(this ILGenerator il, MethodInfo method)
    {
        Guard.NotNull(il);
        Guard.NotNull(method);
        il.Emit(OpCodes.Callvirt, method);
        return il;
    }

    public static ILGenerator callvirt(this ILGenerator il, MethodInfo method, Type[] optionalParameterTypes)
    {
        Guard.NotNull(il);
        Guard.NotNull(method);
        il.EmitCall(OpCodes.Callvirt, method, optionalParameterTypes);
        return il;
    }
}