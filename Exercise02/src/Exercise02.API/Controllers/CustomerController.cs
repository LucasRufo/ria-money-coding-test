using Exercise02.API.Controllers.Shared;
using Exercise02.API.Extensions;
using Exercise02.Domain.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Exercise02.API.Controllers;

[ApiController]
[Route("/customers")]
public class CustomerController : ControllerBase
{
    private IValidator<List<CreateCustomerRequest>> _validator { get; set; }
    public CustomerController(IValidator<List<CreateCustomerRequest>> validator)
    {
        _validator = validator;
    }

    [HttpPost()]
    public async Task<IActionResult> Post(List<CreateCustomerRequest> request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(CustomProblemDetails.CreateValidationProblemDetails(HttpContext.Request.Path, validationResult.ToCustomProblemDetailsError()));

        return Ok();
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok();
    }
}
