using Exercise02.Domain.Entities;

namespace Exercise02.Domain.DataStructures;

public class InternalCustomerArray
{
    public Customer[] Customers { get; private set; }

    public InternalCustomerArray()
    {
        Customers = [];
    }

    public InternalCustomerArray(List<Customer> customers)
    {
        Customers = customers.ToArray();
    }

    public void InsertOrderedByLastAndFirstName(Customer customerToInsert)
    {
        int index = 0;
        while (index < Customers.Length && CompareNamesPrecedence(Customers[index], customerToInsert))
        {
            index++;
        }

        var tempCustomersArray = new Customer[Customers.Length + 1];

        Array.Copy(Customers, 0, tempCustomersArray, 0, index);

        tempCustomersArray[index] = customerToInsert;

        Array.Copy(Customers, index, tempCustomersArray, index + 1, Customers.Length - index);

        Customers = tempCustomersArray;
    }

    private static bool CompareNamesPrecedence(Customer currentCustomer, Customer customerToCompare)
    {
        var hasLastNamePrecedence = currentCustomer.LastName.CompareTo(customerToCompare.LastName) < 0;

        var hasFisrtNamePrecedence = currentCustomer.LastName == customerToCompare.LastName
            && currentCustomer.FirstName.CompareTo(customerToCompare.FirstName) <= 0;

        return hasLastNamePrecedence || hasFisrtNamePrecedence;
    }
}
