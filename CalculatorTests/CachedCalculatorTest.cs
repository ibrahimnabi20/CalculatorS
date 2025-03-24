using CalculatorCore;
using NUnit.Framework;

namespace CalculatorTests;

[TestFixture]
public class CachedCalculatorTest
{
    private CachedCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new CachedCalculator();
    }

    [Test]
    public void Add_ShouldReturnCorrectResult()
    {
        var result = _calculator.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract_ShouldReturnCorrectResult()
    {
        var result = _calculator.Subtract(5, 3);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Multiply_ShouldReturnCorrectResult()
    {
        var result = _calculator.Multiply(4, 2);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Divide_ShouldReturnCorrectResult()
    {
        var result = _calculator.Divide(10, 2);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(5, 0));
    }
}