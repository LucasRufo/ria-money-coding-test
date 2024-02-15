﻿using Exercise02.API.Controllers.Shared;
using FluentValidation.Results;

namespace Exercise02.API.Extensions;

public static class ValidationResultExtensions
{
    public static List<CustomProblemDetailsError> ToCustomProblemDetailsError(this ValidationResult validationResult)
    {
        var customProblemDetailsError = new List<CustomProblemDetailsError>();

        foreach (var error in validationResult.Errors)
            customProblemDetailsError.Add(new CustomProblemDetailsError(error.PropertyName, error.ErrorMessage));

        return customProblemDetailsError;
    }
}
