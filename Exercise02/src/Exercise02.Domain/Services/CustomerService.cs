using ErrorOr;
using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Entities;
using Exercise02.Domain.Repositories;
using Exercise02.Domain.Requests;

namespace Exercise02.Domain.Services;

public class CustomerService
{
    private readonly InternalCustomerArray CustomerArray;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        CustomerArray = new InternalCustomerArray(_customerRepository.GetOrderedByLastAndFisrtName());
    }

    public ErrorOr<Customer[]> InsertMany(List<CreateCustomerRequest> createCustomerRequestList)
    {
        var ids = createCustomerRequestList.Select(x => x.Id);
        var existingIds = CustomerArray.Customers.Where(x => ids.Contains(x.Id)).Select(x => x.Id).ToList();

        if (existingIds.Count != 0)
        {
            return Error.Failure("CustomerIdAlreadyInUse", $"The following customer Ids are already in use: {string.Join(", ", existingIds)}");
        }

        var customerList = Customer.Convert(createCustomerRequestList);

        foreach (var customer in customerList)
        {
            CustomerArray.InsertOrderedByLastAndFirstName(customer);
        }

        _customerRepository.InsertMany(customerList);

        return CustomerArray.Customers;
    }

    public Customer[] Get() => CustomerArray.Customers;
    
}
