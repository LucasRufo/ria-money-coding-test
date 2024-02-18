using Exercise02.Domain.Entities;

namespace Exercise02.Domain.Repositories;

public interface ICustomerRepository
{
    Task InsertMany(List<Customer> customers);
    List<Customer> GetCustomers();
}
