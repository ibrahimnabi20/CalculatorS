namespace CalculatorCore;

public class SimpleCalculator : ICalculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero!");
}