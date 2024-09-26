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
        Assert.Equal(3 + 5 + 7, _calculator.GetResult());
    }

    [Fact]
    public void Subtract_WhenGivenANumber_ShouldSubtractFromAccumulation()
    {
        // Arrange
        var number = 1;

        // Act
        var result = _calculator.Subtract(number);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Subtract_WhenCalledMultipleTimes_ShouldSubtractFromAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3, 5, 7 };

        // Act

        foreach (var num in numbers)
        {
            _calculator.Subtract(num);
        }

        // Assert
        Assert.Equal(-3 - 5 - 7, _calculator.GetResult());
    }

    [Fact]
    public void Multiply_WhenGivenANumber_ShouldMultiplyToAccumulation()
    {
        // Arrange
        var number = 1;

        // Act
        var result = _calculator.Multiply(number);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Multiply_WhenCalledMultipleTimes_ShouldMultiplyToAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3, 5, 1 };

        // Act

        foreach (var num in numbers)
        {
            _calculator.Multiply(num);
        }

        // Assert
        Assert.Equal(3 * 5 * 1, _calculator.GetResult());
    }

    [Fact]
    public void Divide_WhenGivenANumber_ShouldDivideFromAccumulation()
    {
        // Arrange
        var number = 1;
        _calculator.Initialise(1);

        // Act
        var result = _calculator.Divide(number);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Divide_WhenCalledMultipleTimes_ShouldDivideFromAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3m, 5, 1 };
        _calculator.Initialise(1);

        // Act

        foreach (var num in numbers)
        {
            _calculator.Divide(num);
        }

        // Assert
        Assert.Equal(0.0666666666666666666666666667m, _calculator.GetResult());
    }
}