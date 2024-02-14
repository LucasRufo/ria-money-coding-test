using Exercise01.Console;
using FluentAssertions;

namespace Exercise01.Tests;

public class ATMTests
{
    [Test]
    public void ShouldReturnCorrectCombinations()
    {
        var amount = 100;

        var combinations = ATM.CalculateCombinations(amount);

        var expectedCombinations = new List<Combination>()
        {
            new(0, 0, 10),
            new(0, 1, 5),
            new(0, 2, 0),
            new(1, 0, 0)
        };

        combinations.Should().BeEquivalentTo(expectedCombinations);
    }
}