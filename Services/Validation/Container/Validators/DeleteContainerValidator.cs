using FluentValidation;
using Services.Models.Request.Container;

namespace Services.Validation.Container.Validators;

public class DeleteContainerValidator : AbstractValidator<DeleteContainerModel>
{
    public DeleteContainerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}