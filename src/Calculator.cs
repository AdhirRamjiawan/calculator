

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
    private decimal _result;
    private decimal _temp;

    public Calculator()
    {
        _state = State.Cleared;
        _result = 0;
        _temp = 0;
    }

    public decimal Add()
    {
        _result += _temp;
        return _result;
    }

    public void Clear()
    {
        _result = 0;
        _state = State.Cleared;
    }

    public decimal Divide()
    {
        if (_result == 0)
        {
            _state = State.Error;
            return _result;
        }

        _result /= _temp;
        return _result;
    }

    public decimal GetResult() => _result;

    public decimal Multiply()
    {
        if (_state == State.Cleared)
        {
            _result = _temp;
            _state = State.Dirty;
            return _result;
        }

        _result *= _temp;
        return _result;
    }

    public decimal Subtract()
    {
        _result -= _temp;
        return _result;
    }

    public void SetNumber(decimal number)
    {
        if (_state == State.Cleared)
        {
            _result = number;
            _state = State.Dirty;
        }
        else if (_state == State.Dirty)
        {
            _temp = number;
        }
    }
}

public interface ICalculator
{
    public void SetNumber(decimal number);
    public decimal GetResult();
    public void Clear();
    public decimal Add();
    public decimal Subtract();
    public decimal Multiply();
    public decimal Divide();
}