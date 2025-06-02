using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

public sealed class FibonacciEnumerable : IEnumerable<int>
{
    private readonly int _count;
    private readonly int _skipCount;

    public FibonacciEnumerable(int count = int.MaxValue, int skipCount = 0)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        if (skipCount < 0) throw new ArgumentOutOfRangeException(nameof(skipCount));
        _count = count;
        _skipCount = skipCount;
    }

    public IEnumerator<int> GetEnumerator() => new FibonacciEnumerator(_count, _skipCount);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
