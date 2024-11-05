using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Emitted;

public static partial class ILGeneratorExtensions
{
    public static ILGenerator calli(this ILGenerator il, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes)
    {
        Guard.NotNull(il);
        il.EmitCalli(OpCodes.Calli, callingConvention, returnType, parameterTypes, optionalParameterTypes);
        return il;
    }

    public static ILGenerator calli(this ILGenerator il, CallingConvention callingConvention, Type? returnType, Type[]? parameterTypes)
    {
        Guard.NotNull(il);
        il.EmitCalli(OpCodes.Calli, callingConvention, returnType, parameterTypes);
        return il;
    }
}