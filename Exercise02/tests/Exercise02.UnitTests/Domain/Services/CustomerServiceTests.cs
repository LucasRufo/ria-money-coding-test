using ErrorOr;
using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Repositories;
using Exercise02.Domain.Requests;
using Exercise02.Domain.Services;
using Exercise02.TestsShared.Builders.Domain.Requests;
using FakeItEasy;
using FluentAssertions;

namespace Exercise02.UnitTests.Domain.Services;

public class CustomerServiceTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        InternalCustomerArray.Instance.Reset();

        AutoFake.Provide(A.Fake<ICustomerRepository>());
    }

    [Test]
    public async Task ShouldInsertManyOrdered()
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

        var customerList = new List<CreateCustomerRequest>() { customerA, customerB, customerC };

        var result = await AutoFake.Resolve<CustomerService>()
            .InsertMany(customerList);

        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(customerList, x => x.WithStrictOrdering());
    }

    [Test]
    public async Task ShouldReturnErrorWhenAnyIdIsAlreadyInUse()
    {
        var id = 1;
        var customerService = AutoFake.Resolve<CustomerService>();

        var customer = new CreateCustomerRequestBuilder()
            .WithId(id)
            .Generate();

        var list = new List<CreateCustomerRequest>() { customer };

        await customerService.InsertMany(list);

        var result = await customerService.InsertMany(list);

        var error = Error.Failure("CustomerIdAlreadyInUse", $"The following customer Ids are already in use: {id}");

        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(error);
    }
}
