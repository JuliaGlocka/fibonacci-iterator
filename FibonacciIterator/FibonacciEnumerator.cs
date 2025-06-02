using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

public sealed class FibonacciEnumerator : IEnumerator<int>
{
    // Only int fields!
    private int _a, _b;         // Fibonacci state
    private int _index;         // How many in sequence have we advanced (including skips)
    private int _yielded;       // How many have we yielded to the user
    private int _count;         // How many to yield to the user
    private int _skipCount;     // How many to skip at the start
    private int _started;       // 0 = not started, 1 = started, -1 = finished

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
            if (_started != 1)
                throw new InvalidOperationException();
            return _a;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_started == -1)
            return false;

        if (_started == 0)
        {
            // Start and skip skipCount items
            _a = 0;
            _b = 1;
            _index = 0;
            _yielded = 0;

            while (_index < _skipCount)
            {
                int temp = _a + _b;
                _a = _b;
                _b = temp;
                _index++;
            }

            if (_count == 0)
            {
                _started = -1;
                return false;
            }

            _started = 1;
        }
        else
        {
            // Advance to next
            int temp = _a + _b;
            _a = _b;
            _b = temp;
        }

        if (_yielded >= _count)
        {
            _started = -1;
            return false;
        }

        _yielded++;
        return true;
    }

    public void Reset()
    {
        _a = 0;
        _b = 1;
        _index = 0;
        _yielded = 0;
        _started = 0;
    }

    public void Dispose() { }
}
