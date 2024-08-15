using FluentValidation;
using Services.Models.Request.Container;

namespace Services.Validation.Container.Validators;

public class GetContainerByIsoValidator : AbstractValidator<GetContainerByIsoModel>
{
    public GetContainerByIsoValidator()
    {
        RuleFor(x => x.IsoNumber).NotEmpty();
    }
}