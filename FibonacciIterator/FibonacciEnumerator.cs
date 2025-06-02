using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

/// <summary>
/// Represents an enumerator object to iterate over the Fibonacci sequence numbers.
/// </summary>
public sealed class FibonacciEnumerator : IEnumerator<int>
{
    private int _current;
    private int _previous;
    private int _position;
    private readonly int _count;
    private readonly int _skipCount;

    public FibonacciEnumerator(int count, int skipCount)
    {
        _count = count;
        _skipCount = skipCount;
        Reset();
    }

    public int Current => _current;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_position >= _count)
            return false;

        if (_position == 0)
        {
            // Already at the right spot after skipping
        }
        else
        {
            int temp = _current;
            _current += _previous;
            _previous = temp;
        }

        _position++;
        return _position <= _count;
    }

    public void Reset()
    {
        _current = 0;
        _previous = 1;
        _position = 0;

        // Skip the specified number of elements
        for (int i = 0; i < _skipCount; i++)
        {
            int temp = _current;
            _current += _previous;
            _previous = temp;
        }
    }

    public void Dispose()
    {
        // The method is empty, because there are no additional resources to dispose.
        // See "Notes to Implementers" - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1?view=net-6.0#notes-to-implementers
    }
}
