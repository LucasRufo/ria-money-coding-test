using Bogus;
using Exercise02.Domain.Entities;

namespace Exercise02.TestsShared.Builders.Domain.Entities;

public class CustomerBuilder : Faker<Customer>
{
    public CustomerBuilder()
    {
        RuleFor(x => x.Id, faker => faker.Random.Int());
        RuleFor(x => x.FirstName, faker => faker.Person.FirstName);
        RuleFor(x => x.LastName, faker => faker.Person.LastName);
        RuleFor(x => x.Age, faker => faker.Random.Int(19, 119));
    }

    public CustomerBuilder WithId(int id)
    {
        RuleFor(x => x.Id, faker => id);
        return this;
    }

    public CustomerBuilder WithFirstName(string? firstName)
    {
        RuleFor(x => x.FirstName, faker => firstName);
        return this;
    }

    public CustomerBuilder WithLastName(string? lastName)
    {
        RuleFor(x => x.LastName, faker => lastName);
        return this;
    }

    public CustomerBuilder WithAge(int age)
    {
        RuleFor(x => x.Age, faker => age);
        return this;
    }
}
