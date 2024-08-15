using Asp.Versioning;
using AutoMapper;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Type;
using ContainerService.Contracts.Response;
using ContainerService.Contracts.Response.Type;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.Type;
using Services.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/container-types")]
[ApiVersion(1)]
public class TypeController(
    ITypeService typeService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateTypeResponse>>> Create(
        CreateTypeRequest request)
    {
        var id = await typeService.Add(mapper.Map<CreateTypeModel>(request));
        var response = new CreatedResult(
            nameof(Create), new CommonResponse<CreateTypeResponse>
                { Data = new CreateTypeResponse { Id = id } });

        return response;
    }
    
    
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateTypeResponse>>> Update(
        UpdateTypeRequest request)
    {
        var type = await typeService.Update(mapper.Map<UpdateTypeModel>(request));
        var response = new CommonResponse<UpdateTypeResponse>
            { Data = mapper.Map<UpdateTypeResponse>(type) };
     
        return response;
    }
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<CommonResponse<DeleteTypeResponse>>> Delete(
        [FromRoute] DeleteTypeRequest request)
    {
        var type = await typeService.Delete(mapper.Map<DeleteTypeModel>(request));
        var response = new CommonResponse<DeleteTypeResponse>
            { Data = mapper.Map<DeleteTypeResponse>(type) };
     
        return response;
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CommonResponse<GetTypeByIdResponse>>> GetById(
        [FromRoute]GetTypeByIdRequest request)
    {
        var type = await typeService.GetById(mapper.Map<GetTypeByIdModel>(request));
        var response = new CommonResponse<GetTypeByIdResponse>
            { Data = mapper.Map<GetTypeByIdResponse>(type) };
     
        return response;
    }


    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllTypesResponse>>> GetAll(
        [FromQuery] GetAllTypesRequest request)
    {
        var types = await typeService
            .GetAll(mapper.Map<GetAllTypesModel>(request));
        var response = new CommonResponse<GetAllTypesResponse>
            { Data = new GetAllTypesResponse{ Types = mapper.Map<List<TypeApiModel>>(types)} };
        
        return response;
    }
}