using Exercise01.Console;

int[] amounts = [30, 50, 60, 80, 140, 230, 370, 610, 980];

foreach (var amount in amounts)
{
    var combinations = ATM.CalculateCombinations(amount);

    Console.WriteLine();
    Console.WriteLine($"Combinations count {combinations.Count} - Combinations for {amount} EUR:");
    Console.WriteLine();

    foreach (var combination in combinations)
    {
        var resultList = new List<string>();

        if (combination.OneHundredAmount != 0)
            resultList.Add($"{combination.OneHundredAmount} x 100 EUR");

        if (combination.FiftyAmount != 0)
            resultList.Add($"{combination.FiftyAmount} x 50 EUR");

        if (combination.TenAmount != 0)
            resultList.Add($"{combination.TenAmount} x 10 EUR");

        var combinationsResult = string.Join(" + ", resultList);

        Console.WriteLine(combinationsResult);
    }
}
