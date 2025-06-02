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

    public FibonacciEnumerator(int count, int skipCount)
    {
        Count = count;
        SkipCount = skipCount;
        MaxToYield = Math.Max(0, count - skipCount);
        Reset();
    }

    public int Current
    {
        get
        {
            if (Started != 1)
                throw new InvalidOperationException();
            return A;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (Yielded >= MaxToYield)
        {
            Started = -1;
            return false;
        }
        if (Started == 0)
        {
            A = 0;
            B = 1;
            for (int i = 0; i < SkipCount; i++)
            {
                int temp = A;
                A = B;
                B = temp + B;
            }
            Started = 1;
        }
        else
        {
            int temp = A;
            A = B;
            B = temp + B;
        }
        Yielded++;
        return true;
    }

    public void Reset()
    {
        A = 0;
        B = 1;
        Yielded = 0;
        Started = 0;
    }

    public void Dispose() { }
}
