using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type.Validators;

public class DeleteTypeValidator : AbstractValidator<DeleteTypeModel>
{
    public DeleteTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(0);
    }
}