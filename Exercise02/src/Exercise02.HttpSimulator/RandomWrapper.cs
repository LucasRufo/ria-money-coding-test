namespace Exercise02.HttpSimulator;

//The "Random" class is not thread-safe, so I was using an example from this Microsoft blog post: https://devblogs.microsoft.com/pfxteam/getting-random-numbers-in-a-thread-safe-way/
//But since .NET 6, the "Random" class offers a "Shared" static property that is thread-safe.
public static class RandomWrapper
{
    public static int Next(int minValue, int maxValue)
    {
        var value = Random.Shared.Next(minValue, maxValue);

        return value;
    }
}
