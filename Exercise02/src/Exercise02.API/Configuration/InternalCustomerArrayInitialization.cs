using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Repositories;

namespace Exercise02.API.Configuration;

public static class InternalCustomerArrayInitialization
{
    public static void InitalizeInternalCustomerArray(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope(); 

        var customerRepository = serviceScope.ServiceProvider.GetRequiredService<ICustomerRepository>();

        InternalCustomerArray.Instance.Initialize(customerRepository.GetOrderedByLastAndFisrtName());
    }
}
