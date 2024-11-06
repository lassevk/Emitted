namespace Emitted.Tests;

public partial class ILGeneratorExtensionsTests
{
    [Test]
    public void Ldc_I4_0()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_0()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Ldc_I4_1()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_1()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Ldc_I4_2()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_2()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Ldc_I4_3()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_3()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Ldc_I4_4()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_4()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void Ldc_I4_5()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_5()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Ldc_I4_6()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_6()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Ldc_I4_7()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_7()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Ldc_I4_8()
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4_8()
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(8));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(-1)]
    public void Ldc_I4(int value)
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_i4(value)
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(value));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(-1)]
    public void Ldc_auto(int value)
    {
        TestMethod<int> m = Create<int>();
        m.IL
            .ldc_auto(value)
            .ret();

        int result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(value));
    }
}