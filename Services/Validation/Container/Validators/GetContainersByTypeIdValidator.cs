using FluentValidation;
using Services.Models.Request.Container;

namespace Services.Validation.Container.Validators;

public class GetContainersByTypeIdValidator : AbstractValidator<GetContainersByTypeIdModel>
{
    public GetContainersByTypeIdValidator()
    {
        RuleFor(x => x.TypeId)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Page).GreaterThan(0);
        
        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(50);
    }
}