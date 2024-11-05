using System.Reflection.Emit;
// ReSharper disable InconsistentNaming

namespace Emitted;

public static partial class ILGeneratorExtensions
{
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
            -1 => il.ldc_i4_m1(),
            0 => il.ldc_i4_0(),
            1 => il.ldc_i4_1(),
            2 => il.ldc_i4_2(),
            3 => il.ldc_i4_3(),
            4 => il.ldc_i4_4(),
            5 => il.ldc_i4_5(),
            6 => il.ldc_i4_6(),
            7 => il.ldc_i4_7(),
            8 => il.ldc_i4_8(),
            >= -128 and <= 127 => il.ldc_i4_s((sbyte)value),
            _ => il.ldc_i4(value),
        };
    }
}