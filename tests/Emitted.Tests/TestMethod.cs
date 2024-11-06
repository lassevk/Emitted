using System.Reflection.Emit;

namespace Emitted.Tests;

public record TestMethod<TReturn>(ILGenerator IL, Func<Func<TReturn>> GetMethod);