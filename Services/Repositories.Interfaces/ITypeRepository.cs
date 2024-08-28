using Type = Domain.Type;

namespace Services.Repositories.Interfaces;

public interface ITypeRepository
{
    Task<int> AddAsync(Type type);

    Task<Type> UpdateAsync(Type type);

    Task<Type> DeleteAsync(Type type);

    Task<Type> GetByIdAsync(Type type);

    Task<List<Type>> GetAllAsync(int page, int pageSize);

    Task<List<Type>> GetListTypesByIds(List<int> ids);
}