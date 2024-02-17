﻿using Exercise02.Domain.Repositories;
using Exercise02.TestsShared.Builders.Domain.Entities;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise02.IntegrationTests.DatabaseTests.Repositories;

public class CustomerRepositoryTests : BaseIntegrationTests
{
    private ICustomerRepository _customerRepository;

    [SetUp]
    public void SetUp() => _customerRepository = ServiceProvider.GetRequiredService<ICustomerRepository>();

    [Test]
    public async Task ShouldInsertMany()
    {
        var customers = new CustomerBuilder().Generate(3);

        await _customerRepository.InsertMany(customers);

        var customersFromDatabase = ContextForAsserts.Customers.ToList();

        customers.Should().BeEquivalentTo(customersFromDatabase);
    }

    [Test]
    public async Task ShouldGetAllOrderedByLastAndFirstName()
    {
        var customers = new CustomerBuilder().Generate(3);

        await Context.AddRangeAsync(customers);
        await Context.SaveChangesAsync();

        var orderedCustomers = customers
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToList();

        var customersFromDatabase = _customerRepository.GetOrderedByLastAndFisrtName();

        orderedCustomers.Should().BeEquivalentTo(customersFromDatabase);
    }
}