

namespace calculator;

public class Calculator : ICalculator
{
    private decimal _result = 0;

    public decimal Add(decimal number)
    {
        _result += number;
        return _result;
    }

    public void Clear()
    {
        _result = 0;
    }

    public decimal Divide(decimal number)
    {
        throw new System.NotImplementedException();
    }

    public decimal GetResult() => _result;

    public decimal Multiply(decimal number)
    {
        throw new System.NotImplementedException();
    }

    public decimal Subtract(decimal number)
    {
        throw new System.NotImplementedException();
    }
}

public interface ICalculator
{
    public decimal GetResult();
    public void Clear();
    public decimal Add(decimal number);
    public decimal Subtract(decimal number);
    public decimal Multiply(decimal number);
    public decimal Divide(decimal number);
}