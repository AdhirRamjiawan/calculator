

namespace calculator;

public class Calculator : ICalculator
{
    public enum State
    {
        Cleared = 0,
        Dirty,
        Error
    }

    private State _state;
    private decimal _result = 0;

    public Calculator()
    {
        _state = State.Cleared;
    }

    public decimal Add(decimal number)
    {
        _result += number;
        return _result;
    }

    public void Clear()
    {
        _result = 0;
        _state = State.Cleared;
    }

    public decimal Divide(decimal number)
    {
        if (_result == 0)
        {
            _state = State.Error;
            return _result;
        }

        _result /= number;
        return _result;
    }

    public decimal GetResult() => _result;

    public decimal Multiply(decimal number)
    {
        if (_state == State.Cleared)
        {
            _result = number;
            _state = State.Dirty;
            return _result;
        }

        _result *= number;
        return _result;
    }

    public decimal Subtract(decimal number)
    {
        _result -= number;
        return _result;
    }

    public void Initialise(decimal number)
    {
        _result = number;
    }
}

public interface ICalculator
{
    public void Initialise(decimal number);
    public decimal GetResult();
    public void Clear();
    public decimal Add(decimal number);
    public decimal Subtract(decimal number);
    public decimal Multiply(decimal number);
    public decimal Divide(decimal number);
}