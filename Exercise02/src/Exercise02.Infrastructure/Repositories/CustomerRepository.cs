using Exercise02.Domain.Entities;
using Exercise02.Domain.Repositories;

namespace Exercise02.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _customerContext;
    public CustomerRepository(CustomerContext context)
    {
        _customerContext = context;
    }

    public async Task InsertMany(List<Customer> customers)
    {
        //We could use a bulk insert here, but for simplicity, i'm using the AddRangeAsync().
        await _customerContext.Customers.AddRangeAsync(customers);
        await _customerContext.SaveChangesAsync();
    }

    public List<Customer> GetCustomers()
    {
        var customers = _customerContext.Customers.ToList();

        return customers;
    }
}
