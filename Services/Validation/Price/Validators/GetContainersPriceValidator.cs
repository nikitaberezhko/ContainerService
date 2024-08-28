using FluentValidation;
using Services.Models.Request.Price;

namespace Services.Validation.Price.Validators;

public class GetContainersPriceValidator : AbstractValidator<GetContainersPriceModel>
{
    public GetContainersPriceValidator()
    {
        RuleFor(x => x.ContainerIds).NotEmpty();
    }
}