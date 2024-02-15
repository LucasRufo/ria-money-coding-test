using Exercise02.Domain.Requests;
using FluentValidation;

namespace Exercise02.Domain.Validators;

public class CreateCustomerRequestValidator : AbstractValidator<List<CreateCustomerRequest>>
{
    private readonly int MinAge = 18;
    private readonly int MaxAge = 120;
    public CreateCustomerRequestValidator()
    {
        RuleForEach(customer => customer)
            .ChildRules(customer =>
            {
                customer.RuleFor(x => x.Id)
                    .NotEmpty();

                customer.RuleFor(x => x.LastName)
                    .Length(2, 150)
                    .NotEmpty();

                customer.RuleFor(x => x.FirstName)
                    .Length(2, 150)
                    .NotEmpty();

                customer.RuleFor(x => x.Age)
                    .NotEmpty()
                    .GreaterThan(MinAge)
                    .LessThan(MaxAge);
            });
    }
}
