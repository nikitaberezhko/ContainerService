using FluentValidation;
using Services.Models.Request.Container;

namespace Services.Validation.Container.Validators;

public class CreateContainerValidator : AbstractValidator<CreateContainerModel>
{
    public CreateContainerValidator()
    {
        RuleFor(x => x.TypeId)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.IsoNumber).NotEmpty();
    }
}