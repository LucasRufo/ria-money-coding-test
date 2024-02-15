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

        var insertedCustomers = new CustomerService()
            .InsertMany(list);

        insertedCustomers.Should().BeEquivalentTo(list);
    }
}
