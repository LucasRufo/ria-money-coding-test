namespace Exercise02.HttpSimulator;

public static class Counter
{
    private static int _counter = 0;

    public static int GetNextId()
    {
        int id = Interlocked.Increment(ref _counter);
        return id;
    }
}
