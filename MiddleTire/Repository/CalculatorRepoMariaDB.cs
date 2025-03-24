using CalculatorCore;
using MiddleTire.Data;
using MiddleTire.Model;
using MySqlConnector;

namespace MiddleTire.Repository;

public class CalculatorRepoMariaDb
{
    private readonly Lazy<ICalculator> _cachedCalculator = new(() => new CachedCalculator());
    private readonly Lazy<ICalculator> _simpleCalculator = new(() => new SimpleCalculator());

    private readonly string _connectionString;

    public CalculatorRepoMariaDb(IConfiguration configuration)
    {
        _connectionString = configuration["MariaDBConnectionString"]
                            ?? throw new ArgumentNullException("Database connection string missing.");
    }

    public async Task<IResult> Calculate(ICalculatorOperation calculatorOperation)
    {
        ICalculator calculator = calculatorOperation.Calculator switch
        {
            ECalculators.CachedCalculator => _cachedCalculator.Value,
            ECalculators.SimpleCalculator => _simpleCalculator.Value,
            _ => throw new ArgumentException("Invalid calculator type")
        };

        calculatorOperation.Result = calculatorOperation.Operation switch
        {
            ECalculatorOperations.Addition => calculator.Add(calculatorOperation.Number1, calculatorOperation.Number2!.Value),
            ECalculatorOperations.Subtraction => calculator.Subtract(calculatorOperation.Number1, calculatorOperation.Number2!.Value),
            ECalculatorOperations.Multiplication => calculator.Multiply(calculatorOperation.Number1, calculatorOperation.Number2!.Value),
            ECalculatorOperations.Division => calculator.Divide(calculatorOperation.Number1, calculatorOperation.Number2!.Value),
            _ => null
        };

        await StoreCalculationInDatabase(calculatorOperation);
        return Results.Ok(calculatorOperation);
    }

    private async Task StoreCalculationInDatabase(ICalculatorOperation calculatorOperation)
    {
        const string query = "INSERT INTO CalculationHistory (number1, number2, operation, result, calculator) VALUES (@number1, @number2, @operation, @result, @calculator)";
        
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        await using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@number1", calculatorOperation.Number1);
        command.Parameters.AddWithValue("@number2", (object?)calculatorOperation.Number2 ?? DBNull.Value);
        command.Parameters.AddWithValue("@operation", (int)calculatorOperation.Operation);
        command.Parameters.AddWithValue("@result", (object?)calculatorOperation.Result ?? DBNull.Value);
        command.Parameters.AddWithValue("@calculator", (int)calculatorOperation.Calculator);

        await command.ExecuteNonQueryAsync();
    }
}