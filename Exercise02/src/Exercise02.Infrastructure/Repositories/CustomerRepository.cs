﻿using Exercise02.Domain.Entities;
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
        await _customerContext.Customers.AddRangeAsync(customers);
        await _customerContext.SaveChangesAsync();
    }

    public List<Customer> GetOrderedByLastAndFisrtName()
    {
        var customers = _customerContext.Customers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToList();

        return customers;
    }
}