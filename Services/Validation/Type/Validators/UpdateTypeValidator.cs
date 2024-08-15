using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type.Validators;

public class UpdateTypeValidator : AbstractValidator<UpdateTypeModel>
{
    public UpdateTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(0);
        
        RuleFor(x => x.Name).NotEmpty();
        
        RuleFor(x => x.PricePerDay).GreaterThan(0);
    }
}