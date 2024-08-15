using AutoMapper;
using Services.Models.Request.Type;
using Services.Models.Response.Type;
using Type = Domain.Type;

namespace Services.Mapper;

public class ServiceContainerTypeMappingProfile : Profile
{
    public ServiceContainerTypeMappingProfile()
    {
        // Request models -> Domain models
        CreateMap<CreateTypeModel, Type>()
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay))
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        
        CreateMap<DeleteTypeModel, Type>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.Ignore())
            .ForMember(d => d.PricePerDay, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());

        
        CreateMap<GetTypeByIdModel, Type>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.Ignore())
            .ForMember(d => d.PricePerDay, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        CreateMap<UpdateTypeModel, Type>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay))
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        
        
        // Domain models -> Response models
        CreateMap<Type, TypeModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
    }
}