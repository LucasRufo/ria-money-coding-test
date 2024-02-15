using Exercise02.Domain.Requests;
using Exercise02.Domain.Validators;
using Exercise02.TestsShared.Builders.Domain.Requests;
using FluentValidation.TestHelper;

namespace Exercise02.UnitTests.Domain.Validators;

public class CreateCustomerRequestValidatorTests : BaseTests
{
    private readonly CreateCustomerRequestValidator _validator = new();

    [Test]
    public void ShouldNotBeValidWhenIdIsEmpty()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithId(0)
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].Id")
            .WithErrorMessage($"'Id' must not be empty.");
    }

    [Test]
    public void ShouldNotBeValidWhenFirstNameIsEmpty()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithFirstName("")
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].FirstName")
            .WithErrorMessage($"'First Name' must not be empty.");
    }

    [Test]
    public void ShouldNotBeValidWhenFirstNameHasInvalidLength()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithFirstName("a")
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].FirstName")
            .WithErrorMessage($"'First Name' must be between 2 and 150 characters. You entered 1 characters.");
    }

    [Test]
    public void ShouldNotBeValidWhenLastNameIsEmpty()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithLastName("")
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].LastName")
            .WithErrorMessage($"'Last Name' must not be empty.");
    }

    [Test]
    public void ShouldNotBeValidWhenLastNameHasInvalidLength()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithLastName("a")
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].LastName")
            .WithErrorMessage($"'Last Name' must be between 2 and 150 characters. You entered 1 characters.");
    }

    [Test]
    public void ShouldNotBeValidWhenAgeIsEmpty()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithAge(0)
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].Age")
            .WithErrorMessage($"'Age' must not be empty.");
    }

    [Test]
    public void ShouldNotBeValidWhenAgeIsLessThanEighteen()
    {
        var invalidAge = 16;

        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithAge(invalidAge)
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].Age")
            .WithErrorMessage($"'Age' must be greater than '18'.");
    }

    [Test]
    public void ShouldNotBeValidWhenAgeIsGreaterThanOneHundredAndTwenty()
    {
        var invalidAge = 121;

        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithAge(invalidAge)
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>()
        {
            createCustomerRequest
        };

        var validate = _validator.TestValidate(createCustomerRequestList);

        validate.ShouldHaveValidationErrorFor("customer[0].Age")
            .WithErrorMessage($"'Age' must be less than '120'.");
    }
}
