using Exceptions.Contracts.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Models.Request.Type;

namespace Services.Validation.Type;

public class TypeValidator(
    IValidator<CreateTypeModel> createTypeValidator,
    IValidator<UpdateTypeModel> updateTypeValidator,
    IValidator<DeleteTypeModel> deleteTypeValidator,
    IValidator<GetTypeByIdModel> getTypeByIdValidator,
    IValidator<GetAllTypesModel> getAllTypesValidator)
{
    public async Task<bool> ValidateAsync(CreateTypeModel model)
    {
        var validationResult = await createTypeValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(UpdateTypeModel model)
    {
        var validationResult = await updateTypeValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(DeleteTypeModel model)
    {
        var validationResult = await deleteTypeValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(GetTypeByIdModel model)
    {
        var validationResult = await getTypeByIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            ThrowWithStandartErrorMessage();
        
        return true;
    }
    
    public async Task<bool> ValidateAsync(GetAllTypesModel model)
    {
        var validationResult = await getAllTypesValidator.ValidateAsync(model);
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