using Services.Models.Request.Price;
using Services.Models.Response.Price;

namespace Services.Services.Interfaces;

public interface IPriceService
{
    Task<PriceModel> GetPriceForContainers(GetContainersPriceModel model);
}