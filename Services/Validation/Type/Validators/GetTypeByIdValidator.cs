using FluentValidation;
using Services.Models.Request.Type;

namespace Services.Validation.Type;

public class GetTypeByIdValidator : AbstractValidator<GetTypeByIdModel>
{
    public GetTypeByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(0);
    }
}