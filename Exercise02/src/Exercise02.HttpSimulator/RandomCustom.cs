namespace Exercise02.HttpSimulator;

//this is one of the recommended ways of generating random numbers in a thread-safe way.
//ref: https://devblogs.microsoft.com/pfxteam/getting-random-numbers-in-a-thread-safe-way/
public static class RandomCustom
{
    private static Random _global = new();

    [ThreadStatic]
    private static Random? _local;

    public static int Next(int minValue, int maxValue)
    {
        Random? inst = _local;

        if (inst == null)
        {
            int seed;
            lock (_global) seed = _global.Next();
            _local = inst = new Random(seed);
        }

        return inst.Next(minValue, maxValue);
    }
}
