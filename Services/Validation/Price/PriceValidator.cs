using Exceptions.Contracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Models.Request.Price;

namespace Services.Validation.Price;

public class PriceValidator(IValidator<GetContainersPriceModel> getPriceForContainersValidator)
{
    public async Task<bool> ValidateAsync(GetContainersPriceModel model)
    {
        var validationResult = await getPriceForContainersValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
        
        return true;
    }

    private void ThrowWithStandartErrorMessage()
    {
        throw new ServiceException
        {   
            Title = "Model invalid",
            Message = "Model validation failed",
            StatusCode = StatusCodes.Status400BadRequest
        };
    }
}