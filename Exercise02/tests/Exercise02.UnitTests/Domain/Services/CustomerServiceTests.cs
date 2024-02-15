using ErrorOr;
using Exercise02.Domain.Requests;
using Exercise02.Domain.Services;
using Exercise02.TestsShared.Builders.Domain.Requests;
using FluentAssertions;

namespace Exercise02.UnitTests.Domain.Services;

public class CustomerServiceTests : BaseTests
{
    [Test]
    public void ShouldInsertManyOrdered()
    {
        var customerA = new CreateCustomerRequestBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        var customerC = new CreateCustomerRequestBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Cccc")
            .Generate();

        var customerB = new CreateCustomerRequestBuilder()
            .WithLastName("Bbbb")
            .WithFirstName("Bbbb")
            .Generate();

        var list = new List<CreateCustomerRequest>() { customerA, customerB, customerC };

        var result = new CustomerService()
            .InsertMany(list);

        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(list);
    }

    [Test]
    public void ShouldReturnErrorWhenAnyIdIsAlreadyInUse()
    {
        var id = 1;
        var customerService = new CustomerService();

        var customer = new CreateCustomerRequestBuilder()
            .WithId(id)
            .Generate();

        var list = new List<CreateCustomerRequest>() { customer };

        customerService.InsertMany(list);

        var result = customerService.InsertMany(list);

        var error = Error.Failure("CustomerIdAlreadyInUse", $"The following customer Ids are already in use: {id}");

        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(error);
    }
}
