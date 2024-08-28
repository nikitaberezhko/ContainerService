using Services.Models.Request.Price;
using Services.Models.Response.Price;
using Services.Repositories.Interfaces;
using Services.Services.Interfaces;
using Services.Validation.Price;

namespace Services.Services.Implementations;

public class PriceService(
    ITypeRepository typeRepository,
    IContainerRepository containerRepository,
    PriceValidator validator) : IPriceService
{
    public async Task<PriceModel> GetPriceForContainers(
        GetContainersPriceModel model)
    {
        await validator.ValidateAsync(model);

        var containers = await containerRepository
            .GetContainersByListIds(model.ContainerIds);
        var types = await typeRepository
            .GetListTypesByIds(containers.Select(x => x.TypeId).ToList());
        var result = new PriceModel
            { Price = types.Sum(x => x.PricePerDay * containers.Count(y => y.TypeId == x.Id)) };
        
        return result;
    }
}