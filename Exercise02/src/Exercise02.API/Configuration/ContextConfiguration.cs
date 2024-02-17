using Exercise02.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Exercise02.API.Configuration;

public static class ContextConfiguration
{
    public static void AddCustomerDbContext(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddDbContext<CustomerContext>((dbBuilder) =>
        {
            dbBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    options => options.CommandTimeout(30).EnableRetryOnFailure());
        });
    }
}
