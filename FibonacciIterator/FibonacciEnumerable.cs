using System.Collections;

namespace FibonacciIterator;

public sealed class FibonacciEnumerable : IEnumerable<int>
{
    public int Count { get; }

    public int SkipCount { get; }

    public FibonacciEnumerable(int count = int.MaxValue, int skipCount = 0)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (skipCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(skipCount));
        }

        Count = count;
        SkipCount = skipCount;
    }

    public IEnumerator<int> GetEnumerator() => new FibonacciEnumerator(Count, SkipCount);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
