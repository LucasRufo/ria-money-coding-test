using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Repositories;

namespace Exercise02.API.Configuration;

public static class InternalCustomerArrayInitialization
{
    public static void InitalizeInternalCustomerArray(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope(); 

        var customerRepository = serviceScope.ServiceProvider.GetRequiredService<ICustomerRepository>();

        var customers = customerRepository.GetCustomers();

        InternalCustomerArray.Instance.Initialize();

        //Did not know if I could get ordered data from the database (e.g OrderBy)
        //So i'm using the same insertion logic to load the initial data
        foreach (var customer in customers)
        {
            InternalCustomerArray.Instance.InsertOrderedByLastAndFirstName(customer);
        }
    }
}
