using Microsoft.AspNetCore.Mvc;
using CalculatorCore;

[ApiController]
[Route("api")]
public class ComputeController : ControllerBase
{
    private readonly ICalculator _calculator;

    public ComputeController(ICalculator calculator) { _calculator = calculator; }

    [HttpGet("add")]
    public IActionResult Add(int a, int b) => Ok(_calculator.Add(a, b));

    [HttpGet("subtract")]
    public IActionResult Subtract(int a, int b) => Ok(_calculator.Subtract(a, b));

    [HttpGet("multiply")]
    public IActionResult Multiply(int a, int b) => Ok(_calculator.Multiply(a, b));

    [HttpGet("divide")]
    public IActionResult Divide(int a, int b) => Ok(_calculator.Divide(a, b));
}