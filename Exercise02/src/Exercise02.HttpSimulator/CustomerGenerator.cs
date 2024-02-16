using Exercise02.Domain.Requests;

namespace Exercise02.HttpSimulator;

public class CustomerGenerator
{
    private readonly string[] FirstNames = ["Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos"];
    private readonly string[] LastNames = ["Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane"];

    private readonly int MinAge = 10;
    private readonly int MaxAge = 90;

    public List<CreateCustomerRequest> GenerateCustomers(int count)
    {
        var customerList = new List<CreateCustomerRequest>();

        for (int i = 0; i < count; i++)
        {
            var age = RandomCustom.Next(MinAge, MaxAge);

            var customer = new CreateCustomerRequest()
            {
                Id = Counter.GetNextId(),
                Age = age,
                FirstName = FirstNames[RandomCustom.Next(0, FirstNames.Length)],
                LastName = LastNames[RandomCustom.Next(0, LastNames.Length)],
            };

            customerList.Add(customer);
        };

        return customerList;
    }
}
