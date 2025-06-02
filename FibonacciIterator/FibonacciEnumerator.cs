using System.Collections;

namespace FibonacciIterator;

public sealed class FibonacciEnumerator : IEnumerator<int>
{
    public int A { get; private set; }

    public int B { get; private set; }

    public int Yielded { get; private set; }

    public int Count { get; }

    public int SkipCount { get; }

    public int MaxToYield { get; }

    public int Started { get; private set; }

#pragma warning disable SA1201
    public FibonacciEnumerator(int count, int skipCount)
#pragma warning restore SA1201
    {
#pragma warning disable SA1101
        Count = count;
#pragma warning restore SA1101
#pragma warning disable SA1101
        SkipCount = skipCount;
#pragma warning restore SA1101
#pragma warning disable SA1101
        MaxToYield = Math.Max(0, count - skipCount);
#pragma warning restore SA1101
#pragma warning disable SA1101
        Reset();
#pragma warning restore SA1101
    }

    public int Current
    {
        get
        {
#pragma warning disable SA1101
            if (Started != 1)
#pragma warning restore SA1101
            {
                throw new InvalidOperationException();
            }

            return A;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
#pragma warning disable SA1101
        if (Yielded >= MaxToYield)
#pragma warning restore SA1101
        {
#pragma warning disable SA1101
            Started = -1;
#pragma warning restore SA1101
            return false;
        }

        if (Started == 0)
        {
#pragma warning disable SA1101
            A = 0;
#pragma warning restore SA1101
#pragma warning disable SA1101
            B = 1;
#pragma warning restore SA1101
#pragma warning disable SA1101
            for (int i = 0; i < SkipCount; i++)
#pragma warning restore SA1101
            {
#pragma warning disable SA1101
                int temp = A;
#pragma warning restore SA1101
#pragma warning disable SA1101
                A = B;
#pragma warning restore SA1101
#pragma warning disable SA1101
                B = temp + B;
#pragma warning restore SA1101
            }

#pragma warning disable SA1101
            Started = 1;
#pragma warning restore SA1101
        }
        else
        {
            int temp = A;
#pragma warning disable SA1101
            A = B;
#pragma warning restore SA1101
#pragma warning disable SA1101
            B = temp + B;
#pragma warning restore SA1101
        }

#pragma warning disable SA1101
        Yielded++;
#pragma warning restore SA1101
        return true;
    }

    public void Reset()
    {
#pragma warning disable SA1101
        A = 0;
#pragma warning restore SA1101
#pragma warning disable SA1101
        B = 1;
#pragma warning restore SA1101
#pragma warning disable SA1101
        Yielded = 0;
#pragma warning restore SA1101
#pragma warning disable SA1101
        Started = 0;
#pragma warning restore SA1101
    }

    public void Dispose()
    {
    }
}
