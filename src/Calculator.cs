
using static calculator.ICalculator;

namespace calculator;

public class Calculator : ICalculator
{
    public enum State
    {
        Cleared = 0,
        Error
    }

    private Operation _operation;
    private State _state;
    private decimal _result;
    private DecimalStack _input;

    public Calculator()
    {
        _state = State.Cleared;
        _result = 0;
        _input = new DecimalStack();
    }

    public decimal Add()
    {
        while(_input.Count() > 0)
        {
            _result += _input.Pop();
        }

        return _result;
    }

    public void Clear()
    {
        _result = 0;
        _input.Clear();
        _operation = Operation.None;
        _state = State.Cleared;
    }

    public decimal Divide()
    {
        _input.Reverse();
        
        var temp = _input.Pop();

        while(_input.Count() > 0)
        {
            temp /= _input.Pop();
        }

        _result = temp;

        return _result;
    }

    public decimal GetResult() => _result;

    public decimal Multiply()
    {
        var temp = _input.Pop();

        while(_input.Count() > 0)
        {
            temp *= _input.Pop();
        }

        _result = temp;

        return _result;
    }

    public decimal Subtract()
    {
        while(_input.Count() > 0)
        {
            _result -= _input.Pop();
        }

        return _result;
    }

    public void SetNumber(decimal number)
    {
        _input.Push(number);
    }

    public void SetOperation(Operation operation)
    {
        _operation = operation;
    }

    public void ApplyOperation()
    {
        if (_input.Count() < 2)
        {
            return;
        }

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