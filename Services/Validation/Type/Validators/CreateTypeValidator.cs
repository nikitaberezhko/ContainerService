using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type.Validators;

public class CreateTypeValidator : AbstractValidator<CreateTypeModel>
{
    public CreateTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        
        RuleFor(x => x.PricePerDay)
            .NotEmpty()
            .GreaterThan(0);
    }
}