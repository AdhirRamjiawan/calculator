

using System.Collections;
using System.Linq;

namespace calculator;

public class DecimalStack
{
    private readonly Stack _stack;

    public DecimalStack()
    {
        _stack = new Stack();
    }

    public void Push(decimal number)
    {
        _stack.Push(number);
    }

    public decimal Pop()
    {
        return (decimal)_stack.Pop();
    }

    public void Clear()
    {
        _stack.Clear();
    }

    public void Reverse()
    {
        var temp = _stack.ToArray().Reverse();
        _stack.Clear();
        
        foreach (var num in temp)
        {
            _stack.Push(num);
        }
    }

    public int Count() => _stack.Count;
}