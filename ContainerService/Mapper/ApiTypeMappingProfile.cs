using AutoMapper;
using Services.Models.Request.Type;
using Services.Models.Response.Type;
using WebApi.Models.Request.Type;
using WebApi.Models.Response;
using WebApi.Models.Response.Type;

namespace WebApi.Mapper;

public class ApiTypeMappingProfile : Profile
{
    public ApiTypeMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateTypeRequest, CreateTypeModel>()
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
        
        
        CreateMap<UpdateTypeRequest, UpdateTypeModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
        
        
        CreateMap<DeleteTypeRequest, DeleteTypeModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<GetTypeByIdRequest, GetTypeByIdModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<GetAllTypesRequest, GetAllTypesModel>()
            .ForMember(d => d.Page, map => map.MapFrom(c => c.Page))
            .ForMember(d => d.PageSize, map => map.MapFrom(c => c.PageSize));
        
        
        
        // Response models -> Responses
        CreateMap<TypeModel, CreateTypeResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        
        CreateMap<TypeModel, UpdateTypeResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
        
        
        CreateMap<TypeModel, DeleteTypeResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
        
        
        CreateMap<TypeModel, GetTypeByIdResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
        
        
        CreateMap<TypeModel, TypeApiModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.PricePerDay, map => map.MapFrom(c => c.PricePerDay));
    }
}