using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator;

/// <summary>
/// Represents an enumerable object to iterate over the Fibonacci sequence numbers.
/// </summary>
public sealed class FibonacciEnumerable : IEnumerable<int>
{
    private readonly int _count;
    private readonly int _skipCount;

    public FibonacciEnumerable(int count = int.MaxValue, int skipCount = 0)
    {
        _count = count;
        _skipCount = skipCount;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new FibonacciEnumerator(_count, _skipCount);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
