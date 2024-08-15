using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type.Validators;

public class GetAllTypesValidator : AbstractValidator<GetAllTypesModel>
{
    public GetAllTypesValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(50);
    }
}