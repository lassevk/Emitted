using System;
using System.Reflection;
using System.Reflection.Emit;
// ReSharper disable InconsistentNaming

namespace Emitted;

public static partial class ILGeneratorExtensions
{
    public static ILGenerator call(this ILGenerator il, MethodInfo method)
    {
        Guard.NotNull(il);
        Guard.NotNull(method);
        il.Emit(OpCodes.Call, method);
        return il;
    }

    public static ILGenerator call(this ILGenerator il, ConstructorInfo constructor)
    {
        Guard.NotNull(il);
        Guard.NotNull(constructor);
        il.Emit(OpCodes.Call, constructor);
        return il;
    }

    public static ILGenerator call(this ILGenerator il, MethodInfo method, Type[] optionalParameterTypes)
    {
        Guard.NotNull(il);
        Guard.NotNull(method);
        il.EmitCall(OpCodes.Call, method, optionalParameterTypes);
        return il;
    }
}