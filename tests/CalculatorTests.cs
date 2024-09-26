using System.Reflection;
using calculator;

namespace tests;

public class CalculatorTests
{
    private readonly ICalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_WhenGivenANumber_ShouldAddToAccumulation()
    {
        // Arrange
        var number = 1;

        // Act
        var result = _calculator.Add(number);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Add_WhenCalledMultipleTimes_ShouldAddToAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3, 5, 7 };

        // Act

        foreach (var num in numbers)
        {
            _calculator.Add(num);
        }

        // Assert
        Assert.Equal(15, _calculator.GetResult());
    }
}