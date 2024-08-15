using AutoMapper;
using Services.Models.Request.Type;
using Services.Models.Response.Type;
using Services.Repositories.Interfaces;
using Services.Services.Interfaces;
using Services.Validation.Type;
using Type = Domain.Type;

namespace Services.Services.Implementations;

public class TypeService(
    ITypeRepository typeRepository,
    IMapper mapper,
    TypeValidator validator) : ITypeService
{
    public async Task<int> Add(CreateTypeModel model)
    {
        await validator.ValidateAsync(model);
        
        var id = await typeRepository.AddAsync(mapper.Map<Type>(model));
        
        return id;
    }

    public async Task<TypeModel> Update(UpdateTypeModel model)
    {
        await validator.ValidateAsync(model);
        
        var type = await typeRepository.UpdateAsync(mapper.Map<Type>(model));
        var result = mapper.Map<TypeModel>(type);
        
        return result;
    }

    public async Task<TypeModel> Delete(DeleteTypeModel model)
    {
        await validator.ValidateAsync(model);
        
        var type = await typeRepository.DeleteAsync(mapper.Map<Type>(model));
        var result = mapper.Map<TypeModel>(type);
        
        return result;
    }

    public async Task<TypeModel> GetById(GetTypeByIdModel model)
    {
        await validator.ValidateAsync(model);
        
        var type = await typeRepository.GetByIdAsync(mapper.Map<Type>(model));
        var result = mapper.Map<TypeModel>(type);
        
        return result;
    }

    public async Task<List<TypeModel>> GetAll(GetAllTypesModel model)
    {
        await validator.ValidateAsync(model);
        
        var types = await typeRepository.GetAllAsync(
            page: model.Page, 
            pageSize: model.PageSize);
        var result = mapper.Map<List<TypeModel>>(source: types);
        
        return result;
    }
}