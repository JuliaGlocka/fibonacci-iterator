using System;
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
    private int _position; // Position in yield (not in the full sequence)
    private int _fibIndex; // Position in the full sequence (used for skipping)
    private readonly int _count;
    private readonly int _skipCount;
    private bool _started;
    private bool _finished;

    public FibonacciEnumerator(int count, int skipCount)
    {
        _count = count;
        _skipCount = skipCount;
        Reset();
    }

    public int Current
    {
        get
        {
            if (!_started || _finished)
                throw new InvalidOperationException();
            return _current;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_finished || _position >= _count)
        {
            _finished = true;
            return false;
        }

        if (!_started)
        {
            // Set to the first Fibonacci number after skipping
            _current = 0;
            _previous = 1;
            _fibIndex = 0;
            while (_fibIndex < _skipCount)
            {
                int temp = _current;
                _current = _previous;
                _previous = checked(temp + _previous); // checked for overflow (optional)
                _fibIndex++;
            }
            _started = true;
        }
        else
        {
            int temp = _current;
            _current = _previous;
            _previous = checked(temp + _previous); // checked for overflow (optional)
            _fibIndex++;
        }

        _position++;
        if (_position > _count)
        {
            _finished = true;
            return false;
        }

        return true;
    }

    public void Reset()
    {
        _current = 0;
        _previous = 1;
        _position = 0;
        _fibIndex = 0;
        _started = false;
        _finished = false;
    }

    public void Dispose()
    {
        // No resources to dispose.
    }
}
