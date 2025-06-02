using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

public sealed class FibonacciEnumerator : IEnumerator<int>
{
    // Fields
    private int _a, _b;
    private int _index;
    private int _yielded;
    private int _count;
    private int _skipCount;
    private int _maxToYield;
    private int _started; // 0 = not started, 1 = started, -1 = finished

    public FibonacciEnumerator(int count, int skipCount)
    {
        _count = count;
        _skipCount = skipCount;
        _maxToYield = Math.Max(0, count - skipCount);
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
        if (_yielded >= _maxToYield)
        {
            _started = -1;
            return false;
        }
        if (_started == 0)
        {
            _a = 0;
            _b = 1;
            _index = 0;
            for (int i = 0; i < _skipCount; i++)
            {
                int temp = _a + _b;
                _a = _b;
                _b = temp;
            }
            _started = 1;
        }
        else
        {
            int temp = _a + _b;
            _a = _b;
            _b = temp;
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
