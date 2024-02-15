using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Entities;
using Exercise02.Domain.Requests;

namespace Exercise02.Domain.Services;

public class CustomerService
{
    private readonly InternalCustomerArray CustomerArray;

    public CustomerService()
    {
        CustomerArray = new InternalCustomerArray();
    }

    public Customer[] InsertMany(List<CreateCustomerRequest> createCustomerRequestList)
    {
        var customerList = Customer.Convert(createCustomerRequestList);

        foreach (var customer in customerList)
        {
            CustomerArray.InsertOrderedByLastAndFirstName(customer);
        }

        return CustomerArray.Customers;
    }
}
