

using static calculator.ICalculator;

namespace calculator;

public class Calculator : ICalculator
{
    public enum State
    {
        Cleared = 0,
        Dirty,
        Error
    }

    private Operation _operation;
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
        _temp = 0;
        _operation = Operation.None;
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

        if (_operation != Operation.None)
        {
            ApplyOperation();
            _operation = Operation.None;
        }
    }

    public void SetOperation(Operation operation)
    {
        _operation = operation;
    }

    public void ApplyOperation()
    {
        switch(_operation)
        {
            case Operation.Add:
                Add();
                break;
            case Operation.Subtract:
                Subtract();
                break;
            case Operation.Multiply:
                Multiply();
                break;
            case Operation.Divide:
                Divide();
                break;
        }
    }
}

public interface ICalculator
{
    public enum Operation
    {
        None = 0,
        Add,
        Subtract,
        Multiply,
        Divide
    }
    public void SetNumber(decimal number);
    public void SetOperation(Operation operation);
    public void ApplyOperation();
    public decimal GetResult();
    public void Clear();
    public decimal Add();
    public decimal Subtract();
    public decimal Multiply();
    public decimal Divide();
}