using FluentValidation;
using Services.Models.Request.Container;

namespace Services.Validation.Container.Validators;

public class UpdateContainerValidator : AbstractValidator<UpdateContainerModel>
{
    public UpdateContainerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.IsoNumber).NotEmpty();
        
        RuleFor(x => x.IsEngaged).NotNull();
        
        RuleFor(x => x.EngagedUntil)
            .GreaterThan(new DateTime(year: 2020, month: 1, day: 1))
            .Unless(x => x.EngagedUntil is null);
    }
}