using Exceptions.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Interfaces;
using Type = Domain.Type;

namespace Infrastructure.Repositories.Implementations;

public class TypeRepository(DbContext context) : ITypeRepository
{
    public async Task<int> AddAsync(Type type)
    {
        await context.Set<Type>().AddAsync(type);
        await context.SaveChangesAsync();
        
        return type.Id;
    }
    
    public async Task<Type> UpdateAsync(Type type)
    {
        var containerType = await context.Set<Type>()
            .FirstOrDefaultAsync(x => x.Id == type.Id && !x.IsDeleted);
        if (containerType != null)
        {
            context.Entry(containerType).CurrentValues.SetValues(type);
            await context.SaveChangesAsync();
            return containerType;
        }

        throw new InfrastructureException
        {
            Title = "Container type not found",
            Message = $"Container type with id {type.Id} not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<Type> DeleteAsync(Type type)
    {
        var containerType = await context.Set<Type>()
            .FirstOrDefaultAsync(x => x.Id == type.Id && !x.IsDeleted);
        if (containerType != null)
        {
            containerType.IsDeleted = true;
            await context.SaveChangesAsync();
            return containerType;
        }
        
        throw new InfrastructureException
        {
            Title = "Container type not found",
            Message = $"Container type with id {type.Id} not found",
            StatusCode = StatusCodes.Status404NotFound
        }; 
    }

    public async Task<Type> GetByIdAsync(Type type)
    {
        var containerType = await context.Set<Type>()
            .FirstOrDefaultAsync(x => x.Id == type.Id && !x.IsDeleted);
        if (containerType != null)
            return containerType;
        
        throw new InfrastructureException
        {
            Title = "Container type not found",
            Message = $"Container type with id {type.Id} not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }
    
    public async Task<List<Type>> GetAllAsync(int page, int pageSize)
    {
        var types = await context.Set<Type>()
            .Where(x => !x.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return types;
    }
}