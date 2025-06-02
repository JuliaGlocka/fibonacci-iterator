using System.Collections;

namespace FibonacciIterator;

public sealed class FibonacciEnumerable : IEnumerable<int>
{
    public int Count { get; }

    public int SkipCount { get; }

#pragma warning disable SA1201
    public FibonacciEnumerable(int count = int.MaxValue, int skipCount = 0)
#pragma warning restore SA1201
    {
#pragma warning disable CA1512
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }
#pragma warning restore CA1512

#pragma warning disable CA1512
        if (skipCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(skipCount));
        }
#pragma warning restore CA1512

#pragma warning disable SA1101
        Count = count;
#pragma warning restore SA1101
#pragma warning disable SA1101
        SkipCount = skipCount;
#pragma warning restore SA1101
    }

#pragma warning disable SA1101
    public IEnumerator<int> GetEnumerator() => new FibonacciEnumerator(Count, SkipCount);
#pragma warning restore SA1101

#pragma warning disable SA1101
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
#pragma warning restore SA1101
}
