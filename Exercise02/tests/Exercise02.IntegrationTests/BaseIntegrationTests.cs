using Bogus;
using Exercise02.Infrastructure;
using Exercise02.IntegrationTests.ApiTests;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise02.IntegrationTests;

public class BaseIntegrationTests
{
    public Faker Faker;
    public IServiceProvider ServiceProvider;
    public CustomerContext ContextForAsserts;
    public CustomerContext Context;

    private IServiceScope _databaseScope;
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
    public async Task SetUpBase()
    {
        _apiScope = ServiceProvider.CreateScope();
        _databaseScope = ServiceProvider.CreateScope();

        Context = _apiScope.ServiceProvider.GetRequiredService<CustomerContext>();
        ContextForAsserts = _databaseScope.ServiceProvider.GetService<CustomerContext>()!;

        await DatabaseFixture.ResetDatabase();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Context?.Dispose();
        ContextForAsserts?.Dispose();
        TestApi?.Dispose();
        _databaseScope?.Dispose();
        _apiScope?.Dispose();
    }
}
