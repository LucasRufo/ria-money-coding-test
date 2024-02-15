using Exercise02.Domain.Validators;
using FluentValidation;

namespace Exercise02.API.Configuration;

public static class AppServicesConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidators();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        services.AddValidatorsFromAssemblyContaining<CreateCustomerRequestValidator>();

        return services;
    }
}
