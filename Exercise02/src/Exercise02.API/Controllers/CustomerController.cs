﻿using Exercise02.API.Controllers.Shared;
using Exercise02.API.Extensions;
using Exercise02.Domain.Requests;
using Exercise02.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Exercise02.API.Controllers;

[ApiController]
[Route("/customers")]
public class CustomerController : ControllerBase
{
    private IValidator<List<CreateCustomerRequest>> _validator;
    private CustomerService _customerService;
    public CustomerController(IValidator<List<CreateCustomerRequest>> validator, CustomerService customerService)
    {
        _validator = validator;
        _customerService = customerService;
    }

    [HttpPost()]
    public async Task<IActionResult> Post(List<CreateCustomerRequest> request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(CustomProblemDetails.CreateValidationProblemDetails(HttpContext.Request.Path, validationResult.ToCustomProblemDetailsError()));

        _customerService.InsertMany(request);

        return Ok();
    }

    [HttpGet()]
    public IActionResult Get()
    {
        var customers = _customerService.Get();

        return Ok(customers);
    }
}
