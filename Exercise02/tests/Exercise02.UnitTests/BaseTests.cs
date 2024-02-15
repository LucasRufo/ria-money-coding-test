using Autofac.Extras.FakeItEasy;
using Bogus;
using FluentValidation;

namespace Exercise02.UnitTests;

public class BaseTests
{
    protected Faker Faker { get; private set; }
    protected AutoFake AutoFake { get; private set; }

    [OneTimeSetUp]
    public void AllTestsSetUp()
    {
        Faker = new();
        AutoFake = new();

        ValidatorOptions.Global.LanguageManager.Enabled = false;
    }
}
