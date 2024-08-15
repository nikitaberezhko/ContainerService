using AutoMapper;
using Domain;
using Services.Models.Request.Container;
using Services.Models.Response.Container;
using Services.Repositories.Interfaces;
using Services.Services.Interfaces;
using Services.Validation.Container;

namespace Services.Services.Implementations;

public class ContainerService(
    IContainerRepository containerRepository,
    IMapper mapper,
    ContainerValidator validator) : IContainerService
{
    public async Task<Guid> Add(CreateContainerModel model)
    {
        await validator.ValidateAsync(model);

        var id = await containerRepository.AddAsync(mapper.Map<Container>(model));
        
        return id;
    }

    public async Task<ContainerModel> Update(UpdateContainerModel model)
    {
        await validator.ValidateAsync(model);
        
        var container = await containerRepository.UpdateAsync(mapper.Map<Container>(model));
        var result = mapper.Map<ContainerModel>(container);
        
        return result;
    }

    public async Task<ContainerModel> Delete(DeleteContainerModel model)
    {
        await validator.ValidateAsync(model);
        
        var container = await containerRepository.DeleteAsync(mapper.Map<Container>(model));
        var result = mapper.Map<ContainerModel>(container);
        
        return result;
    }

    public async Task<ContainerModel> GetById(GetContainerByIdModel model)
    {
        await validator.ValidateAsync(model);
        
        var container = await containerRepository.GetByIdAsync(mapper.Map<Container>(model));
        var result = mapper.Map<ContainerModel>(container);
        
        return result;
    }

    public async Task<ContainerModel> GetByIso(GetContainerByIsoModel model)
    {
        await validator.ValidateAsync(model);
        
        var container = await containerRepository.GetByIsoAsync(mapper.Map<Container>(model));
        var result = mapper.Map<ContainerModel>(container);
        
        return result;
    }

    public async Task<List<ContainerModel>> GetByTypeId(GetContainersByTypeIdModel model)
    {
        await validator.ValidateAsync(model);
        
        var containers = await containerRepository
            .GetByTypeIdAsync(
                page: model.Page, 
                pageSize: model.PageSize, 
                typeId: model.TypeId);
        var result = mapper.Map<List<ContainerModel>>(source: containers);
        
        return result;
    }
}