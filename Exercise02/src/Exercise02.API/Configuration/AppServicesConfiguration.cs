using Exercise02.Domain.Repositories;
using Exercise02.Domain.Services;
using Exercise02.Domain.Validators;
using Exercise02.Infrastructure.Repositories;
using FluentValidation;

namespace Exercise02.API.Configuration;

public static class AppServicesConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidators();
        services.AddServices();
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<CustomerService>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();

        return services;
    }
}
