using Exercise02.API.Controllers.Shared;
using Exercise02.Domain.Requests;
using Exercise02.IntegrationTests.Extensions;
using Exercise02.TestsShared.Builders.Domain.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace Exercise02.IntegrationTests.ApiTests;

public class CustomerEndpointsTests : BaseIntegrationTests
{
    private HttpClient _httpClient;
    private const string _baseUri = "/customers";

    [SetUp]
    public void SetUp()
    {
        _httpClient = TestApi.CreateClient();
    }

    [Test]
    public async Task PostShouldReturnSuccess()
    {
        var createCustomerRequestList = new CreateCustomerRequestBuilder().Generate(3);

        var response = await _httpClient.PostAsync(_baseUri, createCustomerRequestList.ToJsonContent());

        response.Should().HaveStatusCode(HttpStatusCode.OK);
    }

    [Test]
    public async Task PostShouldReturnBadRequestWhenRequestIsInvalid()
    {
        var createCustomerRequest = new CreateCustomerRequestBuilder()
            .WithId(0)
            .Generate();

        var createCustomerRequestList = new List<CreateCustomerRequest>() { createCustomerRequest };

        var response = await _httpClient.PostAsync(_baseUri, createCustomerRequestList.ToJsonContent());

        var problemDetails = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();

        var customProblemDetailsExpected = CustomProblemDetails.CreateValidationProblemDetails(
            _baseUri,
            new List<CustomProblemDetailsError>()
            {
                new("customer[0].Id", "'Id' must not be empty.")
            });

        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        problemDetails.Should().BeEquivalentTo(customProblemDetailsExpected, ctx => ctx.Excluding(p => p.Type));
    }

    [Test]
    public async Task GetShouldReturnSuccess()
    {
        var response = await _httpClient.GetAsync(_baseUri);

        response.Should().HaveStatusCode(HttpStatusCode.OK);
    }
}
