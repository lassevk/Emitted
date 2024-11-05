using System.Reflection.Emit;

namespace Emitted.Tests;

public record TestMethod<TReturn>(ILGenerator IL, Func<Func<TReturn>> GetMethod);
public record TestMethod<TArg1, TReturn>(ILGenerator IL, Func<Func<TArg1, TReturn>> GetMethod);