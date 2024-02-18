namespace Exercise01.Console;

public class ATM
{
    private static readonly int Cartridge10 = 10;
    private static readonly int Cartridge50 = 50;
    private static readonly int Cartridge100 = 100;

    public static List<Combination> CalculateCombinations(int amount)
    {
        List<Combination> combinations = [];

        var maxCr100Count = amount / Cartridge100;

        for (int cr100Count = 0; cr100Count <= maxCr100Count; cr100Count++)
        {
            var remainingAfterCr100 = amount - cr100Count * Cartridge100;

            var maxCr50Count = remainingAfterCr100 / Cartridge50;

            for (int cr50Count = 0; cr50Count <= maxCr50Count; cr50Count++)
            {
                var remaining = amount - cr100Count * Cartridge100 - cr50Count * Cartridge50;

                if (remaining % Cartridge10 == 0)
                {
                    var cr10Count = remaining / Cartridge10;
                    combinations.Add(new Combination(cr100Count, cr50Count, cr10Count));
                }
            }
        }

        return combinations;
    }
}

public record Combination(int OneHundredAmount, int FiftyAmount, int TenAmount);
