using System;
using System.Runtime.CompilerServices;

namespace Emitted;

internal static class Guard
{
    internal static void NotNull<T>(T value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value == null)
            throw new ArgumentNullException(parameterName);
    }
}