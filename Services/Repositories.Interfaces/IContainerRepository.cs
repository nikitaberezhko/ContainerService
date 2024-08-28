using Domain;

namespace Services.Repositories.Interfaces;

public interface IContainerRepository
{
    Task<Guid> AddAsync(Container container);

    Task<Container> UpdateAsync(Container container);

    Task UpdateEngagedStatusAsync(
        List<Container> containers, 
        Guid orderId, 
        bool isEngaged, 
        DateTime engagedUntil);

    Task<Container> DeleteAsync(Container container);

    Task<Container> GetByIdAsync(Container container);

    Task<Container> GetByIsoAsync(Container container);

    Task<List<Container>> GetByTypeIdAsync(int page, int pageSize, int typeId);

    Task<List<Container>> GetContainersByListIds(List<Guid> ids);
}