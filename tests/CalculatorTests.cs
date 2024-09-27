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
        _calculator.SetNumber(number);
        _calculator.SetNumber(1);
        _calculator.SetOperation(ICalculator.Operation.Add);

        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(2, _calculator.GetResult());
    }

    [Fact]
    public void Add_WhenCalledMultipleTimes_ShouldAddToAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3, 5, 7 };
        _calculator.SetOperation(ICalculator.Operation.Add);

        foreach (var num in numbers)
        {
            _calculator.SetNumber(num);
        }

        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(3 + 5 + 7, _calculator.GetResult());
    }

    [Fact]
    public void Subtract_WhenGivenANumber_ShouldSubtractFromAccumulation()
    {
        // Arrange
        var number = 1;
        _calculator.SetNumber(0);

        // Act
        _calculator.SetNumber(number);
        var result = _calculator.Subtract();

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Subtract_WhenCalledMultipleTimes_ShouldSubtractFromAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3, 5, 7 };

        _calculator.SetOperation(ICalculator.Operation.Subtract);

        foreach (var num in numbers)
        {
            _calculator.SetNumber(num);
        }


        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(-3 - 5 - 7, _calculator.GetResult());
    }

    [Fact]
    public void Multiply_WhenGivenANumber_ShouldMultiplyToAccumulation()
    {
        // Arrange
        var number = 4;
        _calculator.SetNumber(3);
        _calculator.SetNumber(number);

        _calculator.SetOperation(ICalculator.Operation.Multiply);

        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(12, _calculator.GetResult());
    }

    [Fact]
    public void Multiply_WhenCalledMultipleTimes_ShouldMultiplyToAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{3, 5, 1 };

        _calculator.SetOperation(ICalculator.Operation.Multiply);

        foreach (var num in numbers)
        {
            _calculator.SetNumber(num);
        }        

        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(3 * 5 * 1, _calculator.GetResult());
    }

    [Fact]
    public void Divide_WhenGivenANumber_ShouldDivideFromAccumulation()
    {
        // Arrange
        var number = 1;
        _calculator.SetNumber(number);
        _calculator.SetNumber(1);

        // Act
        var result = _calculator.Divide();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Divide_WhenCalledMultipleTimes_ShouldDivideFromAccumulation()
    {
        // Arrange
        var numbers = new decimal[]{ 3m, 5, 1 };

        _calculator.SetOperation(ICalculator.Operation.Divide);

        foreach (var num in numbers)
        {
            _calculator.SetNumber(num);
        }

        // Act
        _calculator.ApplyOperation();

        // Assert
        Assert.Equal(0.0666666666666666666666666667m, _calculator.GetResult());
    }
}