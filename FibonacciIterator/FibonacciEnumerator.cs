using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

public sealed class FibonacciEnumerator : IEnumerator<int>
{
    private int _current;    // Current Fibonacci number
    private int _prev;       // Previous Fibonacci number
    private int _yielded;    // How many values have been yielded
    private int _count;      // Total number to yield
    private int _skip;       // How many to skip
    private int _started;    // 0 = not started, 1 = started
    private int _valid;      // 1 = valid position, 0 = not valid

    public FibonacciEnumerator(int count, int skip)
    {
        _count = count;
        _skip = skip;
        Reset();
    }

    public int Current
    {
        get
        {
            if (_valid == 0) throw new InvalidOperationException();
            return _current;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_yielded >= _count)
        {
            _valid = 0;
            return false;
        }

        if (_started == 0)
        {
            // Initialize sequence
            _current = 0;
            _prev = 1;
            // Skip the first _skip items
            for (int i = 0; i < _skip; i++)
            {
                int temp = _current;
                _current = _prev;
                _prev = temp + _prev;
            }
            _started = 1;
        }
        else
        {
            int temp = _current;
            _current = _prev;
            _prev = temp + _prev;
        }

        _yielded++;
        _valid = 1;
        return true;
    }

    public void Reset()
    {
        _current = 0;
        _prev = 1;
        _yielded = 0;
        _started = 0;
        _valid = 0;
    }

    public void Dispose() { }
}
