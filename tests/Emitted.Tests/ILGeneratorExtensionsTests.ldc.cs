namespace Emitted.Tests;

public partial class ILGeneratorExtensionsTests
{
    [Test]
    public void Ldc_I4_0()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_0()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Ldc_I4_1()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_1()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Ldc_I4_2()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_2()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Ldc_I4_3()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_3()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Ldc_I4_4()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_4()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void Ldc_I4_5()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_5()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Ldc_I4_6()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_6()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Ldc_I4_7()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_7()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Ldc_I4_8()
    {
        var m = Create<int>();
        m.IL
            .ldc_i4_8()
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(8));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(-1)]
    public void Ldc_I4(int value)
    {
        var m = Create<int>();
        m.IL
            .ldc_i4(value)
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(value));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(-1)]
    public void Ldc_auto(int value)
    {
        var m = Create<int>();
        m.IL
            .ldc_auto(value)
            .ret();

        var result = m.GetMethod()();
        Assert.That(result, Is.EqualTo(value));
    }
}