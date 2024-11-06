using System.Reflection;
using System.Reflection.Emit;

namespace Emitted.Tests;

public partial class ILGeneratorExtensionsTests
{
    private TestMethod<TReturn> Create<TReturn>()
    {
        var method = new DynamicMethod("method", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(TReturn), Type.EmptyTypes,
            Assembly.GetExecutingAssembly().Modules.First(), true);

        return new TestMethod<TReturn>(method.GetILGenerator(), () => method.CreateDelegate<Func<TReturn>>());
    }

    private static IEnumerable<string> OpCodes()
    {
        foreach (FieldInfo field in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            if (field.FieldType != typeof(OpCode))
                continue;

            if (field.Name.StartsWith("Prefix"))
                continue;

            yield return field.Name;
        }
    }

    [TestCaseSource(nameof(OpCodes))]
    public void OpCodeImplemented(string name)
    {
        var methods = typeof(ILGeneratorExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == name.ToLowerInvariant()).ToList();

        Assert.IsNotEmpty(methods);
    }
}