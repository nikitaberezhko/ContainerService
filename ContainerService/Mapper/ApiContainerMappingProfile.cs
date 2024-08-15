using AutoMapper;
using Services.Models.Request.Container;
using Services.Models.Response.Container;
using WebApi.Models.Request.Container;
using WebApi.Models.Response;
using WebApi.Models.Response.Container;

namespace WebApi.Mapper;

public class ApiContainerMappingProfile : Profile
{
    public ApiContainerMappingProfile()
    {
        // Request -> Request models
        CreateMap<CreateContainerRequest, CreateContainerModel>()
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber));
        
        
        CreateMap<UpdateContainerRequest, UpdateContainerModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));


        CreateMap<DeleteContainerRequest, DeleteContainerModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<GetContainerByIdRequest, GetContainerByIdModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<GetContainerByIsoRequest, GetContainerByIsoModel>()
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber));
        
        
        CreateMap<GetContainersByTypeIdRequest, GetContainersByTypeIdModel>()
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.Page, map => map.MapFrom(c => c.Page))
            .ForMember(d => d.PageSize, map => map.MapFrom(c => c.PageSize));
        
        
        
        // Response models -> Responses
        CreateMap<ContainerModel, CreateContainerResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<ContainerModel, UpdateContainerResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
        
        
        CreateMap<ContainerModel, DeleteContainerResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
        
        
        CreateMap<ContainerModel, GetContainerByIdResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
        
        
        CreateMap<ContainerModel, GetContainerByIsoResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
        
        
        CreateMap<ContainerModel, ContainerApiModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.OrderId, map => map.MapFrom(c => c.OrderId))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
    }
}