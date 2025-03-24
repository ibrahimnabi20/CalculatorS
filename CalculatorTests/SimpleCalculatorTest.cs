using CalculatorCore;
using NUnit.Framework;

namespace CalculatorTests;

[TestFixture]
public class SimpleCalculatorTest
{
    private SimpleCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new SimpleCalculator();
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
}