using Exercise02.Domain.DataStructures;
using Exercise02.Domain.Entities;
using Exercise02.TestsShared.Builders.Domain.Entities;
using FluentAssertions;

namespace Exercise02.UnitTests.Domain.DataStructures;

public class InternalCustomerArrayTests : BaseTests
{
    [Test]
    public void ShouldInsertCustomerOrderedByLastName()
    {
        var customerA = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        var customerC = new CustomerBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Cccc")
            .Generate();

        var list = new List<Customer>() { customerA, customerC };

        var internalCustomerArray = new InternalCustomerArray(list);

        var customerB = new CustomerBuilder()
            .WithLastName("Bbbb")
            .WithFirstName("Bbbb")
            .Generate();

        internalCustomerArray.InsertOrderedByLastAndFirstName(customerB);

        var expectedList = new List<Customer>() { customerA, customerB, customerC };

        internalCustomerArray.Customers.Should().BeEquivalentTo(expectedList);
    }

    [Test]
    public void ShouldInsertCustomerOrderedByLastNameThenFirstName()
    {
        var customerA = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        var customerC = new CustomerBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Cccc")
            .Generate();

        var list = new List<Customer>() { customerA, customerC };

        var internalCustomerArray = new InternalCustomerArray(list);

        var customerB = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Bbbb")
            .Generate();

        internalCustomerArray.InsertOrderedByLastAndFirstName(customerB);

        var expectedList = new List<Customer>() { customerA, customerB, customerC };

        internalCustomerArray.Customers.Should().BeEquivalentTo(expectedList);
    }

    [Test]
    public void ShouldInsertCustomerOrderedByLastNameThenFirstNameWhenLastAndFirstNamesAreEqual()
    {
        var customerA = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        var customerC = new CustomerBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Cccc")
            .Generate();

        var list = new List<Customer>() { customerA, customerC };

        var internalCustomerArray = new InternalCustomerArray(list);

        var customerAReapeted = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        internalCustomerArray.InsertOrderedByLastAndFirstName(customerAReapeted);

        var expectedList = new List<Customer>() { customerA, customerAReapeted, customerC };

        internalCustomerArray.Customers.Should().BeEquivalentTo(expectedList);
    }

    [Test]
    public void ShouldInsertOrderedUsingExampleFromDocs()
    {
        var customerA = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Aaaa")
            .Generate();

        var customerB = new CustomerBuilder()
            .WithLastName("Aaaa")
            .WithFirstName("Bbbb")
            .Generate();

        var customerC = new CustomerBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Aaaa")
            .Generate();

        var customerD = new CustomerBuilder()
            .WithLastName("Cccc")
            .WithFirstName("Bbbb")
            .Generate();

        var customerE = new CustomerBuilder()
            .WithLastName("Dddd")
            .WithFirstName("Aaaa")
            .Generate();

        var list = new List<Customer>() { customerA, customerB, customerC, customerD, customerE };

        var internalCustomerArray = new InternalCustomerArray(list);

        var firstCustomerToInsert = new CustomerBuilder()
            .WithLastName("Bbbb")
            .WithFirstName("Bbbb")
            .Generate();

        internalCustomerArray.InsertOrderedByLastAndFirstName(firstCustomerToInsert);

        var expectedList = new List<Customer>() { customerA, customerB, firstCustomerToInsert, customerC, customerD, customerE };

        internalCustomerArray.Customers.Should().BeEquivalentTo(expectedList);

        var secondCustomerToInsert = new CustomerBuilder()
            .WithLastName("Bbbb")
            .WithFirstName("Aaaa")
            .Generate();

        internalCustomerArray.InsertOrderedByLastAndFirstName(secondCustomerToInsert);

        var secondExpectedList = new List<Customer>() { customerA, customerB, secondCustomerToInsert, firstCustomerToInsert, customerC, customerD, customerE };

        internalCustomerArray.Customers.Should().BeEquivalentTo(secondExpectedList);
    }
}
