using Services.Models.Request.Container;
using Services.Models.Response.Container;

namespace Services.Services.Interfaces;

public interface IContainerService
{
    Task<Guid> Add(CreateContainerModel model);

    Task<ContainerModel> Update(UpdateContainerModel model);

    Task<ContainerModel> Delete(DeleteContainerModel model);

    Task<ContainerModel> GetById(GetContainerByIdModel model);

    Task<ContainerModel> GetByIso(GetContainerByIsoModel model);

    Task<List<ContainerModel>> GetByTypeId(GetContainersByTypeIdModel model);
}
