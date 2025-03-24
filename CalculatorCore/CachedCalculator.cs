using System.Collections.Generic;

namespace CalculatorCore;

public class CachedCalculator : ICalculator
{
    private readonly SimpleCalculator _calculator = new();
    private readonly Dictionary<string, int> _cache = new();

    private int FetchOrCompute(int a, int b, string op, System.Func<int> computation)
    {
        string key = $"{a}{op}{b}";
        if (!_cache.ContainsKey(key))
            _cache[key] = computation();

    public int Add(int a, int b) => FetchOrCompute(a, b, "+", () => _calculator.Add(a, b));
    public int Subtract(int a, int b) => FetchOrCompute(a, b, "-", () => _calculator.Subtract(a, b));
    public int Multiply(int a, int b) => FetchOrCompute(a, b, "*", () => _calculator.Multiply(a, b));
    public int Divide(int a, int b) => FetchOrCompute(a, b, "/", () => _calculator.Divide(a, b));
}