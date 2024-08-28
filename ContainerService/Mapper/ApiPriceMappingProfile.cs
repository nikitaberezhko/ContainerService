using AutoMapper;
using ContainerService.Contracts.Request.Price;
using ContainerService.Contracts.Response.Price;
using Services.Models.Request.Price;
using Services.Models.Response.Price;

namespace WebApi.Mapper;

public class ApiPriceMappingProfile : Profile
{
    public ApiPriceMappingProfile()
    {
        // Request -> Request models
        CreateMap<GetContainersPriceRequest, GetContainersPriceModel>()
            .ForMember(d => d.ContainerIds, map => map.MapFrom(c => c.ContainerIds));
        
        
        
        // Response models -> Responses
        CreateMap<PriceModel, GetContainersPriceResponse>()
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
    }
}