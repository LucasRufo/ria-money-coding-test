using Exercise02.Domain.Requests;

namespace Exercise02.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }

    public static List<Customer> Convert(List<CreateCustomerRequest> createCustomerRequestList)
    {
        var list = new List<Customer>();

        foreach (var request in createCustomerRequestList)
        {
            list.Add(new Customer() 
            { 
                Id = request.Id,
                Age = request.Age,
                FirstName = request.FirstName!,
                LastName = request.LastName!
            });
        }

        return list;
    }
}