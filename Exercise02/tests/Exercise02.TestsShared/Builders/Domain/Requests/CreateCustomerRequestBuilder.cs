using Bogus;
using Exercise02.Domain.Requests;

namespace Exercise02.TestsShared.Builders.Domain.Requests;

public class CreateCustomerRequestBuilder : Faker<CreateCustomerRequest>
{
    public CreateCustomerRequestBuilder()
    {
        RuleFor(x => x.Id, faker => faker.Random.Int());
        RuleFor(x => x.FirstName, faker => faker.Person.FirstName);
        RuleFor(x => x.LastName, faker => faker.Person.LastName);
        RuleFor(x => x.Age, faker => faker.Random.Int(19, 119));
    }

    public CreateCustomerRequestBuilder WithId(int id)
    {
        RuleFor(x => x.Id, faker => id);
        return this;
    }

    public CreateCustomerRequestBuilder WithFirstName(string? firstName)
    {
        RuleFor(x => x.FirstName, faker => firstName);
        return this;
    }

    public CreateCustomerRequestBuilder WithLastName(string? lastName)
    {
        RuleFor(x => x.LastName, faker => lastName);
        return this;
    }

    public CreateCustomerRequestBuilder WithAge(int age)
    {
        RuleFor(x => x.Age, faker => age);
        return this;
    }
}
