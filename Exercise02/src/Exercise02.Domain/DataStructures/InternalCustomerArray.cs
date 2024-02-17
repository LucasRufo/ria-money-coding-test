using Exercise02.Domain.Entities;

namespace Exercise02.Domain.DataStructures;

public class InternalCustomerArray
{
    private static readonly InternalCustomerArray instance = new();
    private static bool isInitialized { get; set; }

    public Customer[] Customers { get; private set; }

    private readonly object _lock = new();

    private InternalCustomerArray() 
    {
        Customers = [];   
    }

    public static InternalCustomerArray Instance
    {
        get { return instance; }
    }

    public void Initialize(List<Customer>? customers = null)
    {
        if (!isInitialized)
        {
            Customers = customers?.ToArray() ?? [];
            isInitialized = true;
        }
    }

    public void Reset()
    {
        Customers = [];
        isInitialized = false;
    }

    public void InsertOrderedByLastAndFirstName(Customer customerToInsert)
    {
        lock (_lock)
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
    }

    private static bool CompareNamesPrecedence(Customer currentCustomer, Customer customerToCompare)
    {
        var hasLastNamePrecedence = string.Compare(currentCustomer.LastName, customerToCompare.LastName, StringComparison.OrdinalIgnoreCase) < 0;

        var hasFisrtNamePrecedence = string.Equals(currentCustomer.LastName, customerToCompare.LastName, StringComparison.OrdinalIgnoreCase)
            && string.Compare(currentCustomer.FirstName, customerToCompare.FirstName, StringComparison.OrdinalIgnoreCase) <= 0;

        return hasLastNamePrecedence || hasFisrtNamePrecedence;
    }
}
