using Asp.Versioning;
using AutoMapper;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Price;
using ContainerService.Contracts.Response.Price;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.Price;
using Services.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/price")]
[ApiVersion(1)]
public class PriceController(
    IMapper mapper,
    IPriceService priceService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersPriceResponse>>> GetPrice(
        GetContainersPriceRequest request)
    {
        var price = await priceService
            .GetPriceForContainers(mapper.Map<GetContainersPriceModel>(request));
        var response = new CommonResponse<GetContainersPriceResponse>
            { Data = mapper.Map<GetContainersPriceResponse>(price) };

        return response;
    }
}