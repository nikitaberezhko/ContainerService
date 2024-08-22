using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type.Validators;

public class GetTypeByIdValidator : AbstractValidator<GetTypeByIdModel>
{
    public GetTypeByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}