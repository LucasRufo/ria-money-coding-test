using Bogus;
using Exercise02.IntegrationTests.ApiTests;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise02.IntegrationTests;

public class BaseIntegrationTests
{
    public Faker Faker;
    public IServiceProvider ServiceProvider;

    private IServiceScope _apiScope;

    protected TestApplication TestApi;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        TestApi = new TestApplication();
        ServiceProvider = TestApi.Services;
        Faker = new Faker();

        ValidatorOptions.Global.LanguageManager.Enabled = false;
    }

    [SetUp]
    public void SetUpBase()
    {
        _apiScope = ServiceProvider.CreateScope();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        TestApi?.Dispose();
        _apiScope?.Dispose();
    }
}
