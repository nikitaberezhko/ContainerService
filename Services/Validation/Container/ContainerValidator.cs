using Exceptions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Models.Request.Container;

namespace Services.Validation.Container;

public class ContainerValidator(
    IValidator<CreateContainerModel> createContainerValidator,
    IValidator<UpdateContainerModel> updateContainerValidator,
    IValidator<DeleteContainerModel> deleteContainerValidator,
    IValidator<GetContainerByIdModel> getContainerByIdValidator,
    IValidator<GetContainerByIsoModel> getContainerByIsoValidator,
    IValidator<GetContainersByTypeIdModel> getContainersByTypeIdValidator)
{
    public async Task ValidateAsync(CreateContainerModel model)
    {
        var validationResult = await createContainerValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
    }
    
    public async Task ValidateAsync(UpdateContainerModel model)
    {
        var validationResult = await updateContainerValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
    }
    
    public async Task ValidateAsync(DeleteContainerModel model)
    {  
        var validationResult = await deleteContainerValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
    }
    
    public async Task ValidateAsync(GetContainerByIdModel model)
    {
        var validationResult = await getContainerByIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
    }
    
    public async Task ValidateAsync(GetContainerByIsoModel model)
    {
        var validationResult = await getContainerByIsoValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
    }
    
    public async Task ValidateAsync(GetContainersByTypeIdModel model)
    {  
        var validationResult = await getContainersByTypeIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
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