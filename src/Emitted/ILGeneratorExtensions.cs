using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace Emitted;

[PublicAPI]
public static partial class ILGeneratorExtensions
{
    public static ILGenerator scope(this ILGenerator il, Action<ILGenerator> scopedCode)
    {
        Guard.NotNull(il);
        Guard.NotNull(scopedCode);

        il.BeginScope();
        scopedCode(il);
        il.EndScope();
        return il;
    }

    public static ILGenerator @try(this ILGenerator il, Action<ILGenerator> tryCode)
    {
        Guard.NotNull(il);
        Guard.NotNull(tryCode);

        il.BeginExceptionBlock();
        tryCode(il);
        il.EndExceptionBlock();
        return il;
    }

    public static ILGenerator @catch(this ILGenerator il, Type exceptionType, Action<ILGenerator> catchBlockCode)
    {
        Guard.NotNull(il);
        Guard.NotNull(exceptionType);
        Guard.NotNull(catchBlockCode);

        il.BeginCatchBlock(exceptionType);
        catchBlockCode(il);
        return il;
    }

    public static ILGenerator @finally(this ILGenerator il, Action<ILGenerator> finallyCode)
    {
        Guard.NotNull(il);
        Guard.NotNull(finallyCode);

        il.BeginFinallyBlock();
        finallyCode(il);
        il.endfinally();
        return il;
    }

    public static ILGenerator @throw(this ILGenerator il, Type exceptionType)
    {
        Guard.NotNull(il);
        Guard.NotNull(exceptionType);
        il.ThrowException(exceptionType);
        return il;
    }

    public static ILGenerator @throw<T>(this ILGenerator il)
        where T : Exception
        => @throw(il, typeof(T));

    public static LocalBuilder DeclareLocal<T>(this ILGenerator il, bool pinned = false)
    {
        Guard.NotNull(il);
        return il.DeclareLocal(typeof(T), pinned);
    }

    public static ILGenerator local(this ILGenerator il, Type type, bool pinned = false)
    {
        Guard.NotNull(il);
        il.DeclareLocal(type, pinned);
        return il;
    }

    public static ILGenerator local<T>(this ILGenerator il, bool pinned = false) => local(il, typeof(T), pinned);

    public static ILGenerator mark(this ILGenerator il, Label label)
    {
        Guard.NotNull(il);
        Guard.NotNull(label);
        il.MarkLabel(label);
        return il;
    }

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

    /// <summary>
    /// Emits one of the "Ldc_I4_*" opcodes, depending on the value.
    /// </summary>
    /// <param name="il">
    /// The <see cref="ILGenerator"/> to emit the opcode to.
    /// </param>
    /// <param name="value">
    /// The value to push onto the stack.
    /// </param>
    /// <returns>
    /// The <see cref="ILGenerator"/> passed in through <paramref name="il"/>.
    /// </returns>
    public static ILGenerator ldc_auto(this ILGenerator il, int value)
    {
        return value switch
        {
            -1                 => il.ldc_i4_m1(),
            0                  => il.ldc_i4_0(),
            1                  => il.ldc_i4_1(),
            2                  => il.ldc_i4_2(),
            3                  => il.ldc_i4_3(),
            4                  => il.ldc_i4_4(),
            5                  => il.ldc_i4_5(),
            6                  => il.ldc_i4_6(),
            7                  => il.ldc_i4_7(),
            8                  => il.ldc_i4_8(),
            >= -128 and <= 127 => il.ldc_i4_s((sbyte)value),
            _                  => il.ldc_i4(value),
        };
    }

    public static ILGenerator box<T>(this ILGenerator il) => il.box(typeof(T));

    /// <summary>
    /// Emits the opcode <see cref="OpCodes.Switch"/>
    /// </summary>
    /// <param name="il">
    /// The <see cref="ILGenerator" /> to emit the opcode to.
    /// </param>
    /// <param name="value">
    /// The <see cref="Label"/> array to emit with the opcode.
    /// </param>
    /// <returns>
    /// The <see cref="ILGenerator"/> passed in through <paramref name="il"/>.
    /// </returns>
    public static ILGenerator @switch(this ILGenerator il, Label[] value)
    {
        Guard.NotNull(il);
        il.Emit(OpCodes.Switch, value);
        return il;
    }
}