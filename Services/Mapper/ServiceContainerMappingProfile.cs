using AutoMapper;
using Domain;
using Services.Models.Request.Container;
using Services.Models.Response.Container;

namespace Services.Mapper;

public class ServiceContainerMappingProfile : Profile
{
    public ServiceContainerMappingProfile()
    {
        // Request models -> Domain models
        CreateMap<CreateContainerModel, Container>()
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.OrderId, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Type, map => map.Ignore())
            .ForMember(d => d.IsEngaged, map => map.Ignore())
            .ForMember(d => d.EngagedUntil, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<DeleteContainerModel, Container>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.OrderId, map => map.Ignore())
            .ForMember(d => d.IsoNumber, map => map.Ignore())
            .ForMember(d => d.TypeId, map => map.Ignore())
            .ForMember(d => d.Type, map => map.Ignore())
            .ForMember(d => d.IsEngaged, map => map.Ignore())
            .ForMember(d => d.EngagedUntil, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<GetContainerByIdModel, Container>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.OrderId, map => map.Ignore())
            .ForMember(d => d.IsoNumber, map => map.Ignore())
            .ForMember(d => d.TypeId, map => map.Ignore())
            .ForMember(d => d.Type, map => map.Ignore())
            .ForMember(d => d.IsEngaged, map => map.Ignore())
            .ForMember(d => d.EngagedUntil, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());;


        CreateMap<GetContainerByIsoModel, Container>()
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.TypeId, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.OrderId, map => map.Ignore())
            .ForMember(d => d.Type, map => map.Ignore())
            .ForMember(d => d.IsEngaged, map => map.Ignore())
            .ForMember(d => d.EngagedUntil, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());;


        CreateMap<UpdateContainerModel, Container>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil))
            .ForMember(d => d.OrderId, map => map.Ignore())
            .ForMember(d => d.Type, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());

        

        // Domain models -> Response models
        CreateMap<Container, ContainerModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.OrderId, map => map.MapFrom(c => c.OrderId))
            .ForMember(d => d.IsoNumber, map => map.MapFrom(c => c.IsoNumber))
            .ForMember(d => d.TypeId, map => map.MapFrom(c => c.TypeId))
            .ForMember(d => d.IsEngaged, map => map.MapFrom(c => c.IsEngaged))
            .ForMember(d => d.EngagedUntil, map => map.MapFrom(c => c.EngagedUntil));
    }
}