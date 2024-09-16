using Asp.Versioning;
using AutoMapper;
using CommonModel.Contracts;
using ContainerService.Contracts.Request.Container;
using ContainerService.Contracts.Response;
using ContainerService.Contracts.Response.Container;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.Container;
using Services.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/containers")]
[ApiVersion(1)]
public class ContainerController(
    IContainerService containerService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateContainerResponse>>> Create(
        CreateContainerRequest request)
    {
        var id = await containerService.Add(mapper.Map<CreateContainerModel>(request));
        var response = new CreatedResult(
            nameof(Create), new CommonResponse<CreateContainerResponse>
                { Data = new CreateContainerResponse { Id = id } });

        return response;
    }

    
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateContainerResponse>>> Update(
        UpdateContainerRequest request)
    {
        var container = await containerService.Update(mapper.Map<UpdateContainerModel>(request));
        var response = new CommonResponse<UpdateContainerResponse> 
            { Data = mapper.Map<UpdateContainerResponse>(container) };

        return response;
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<CommonResponse<DeleteContainerResponse>>> Delete(
        [FromRoute] DeleteContainerRequest request)
    {
        var container = await containerService.Delete(mapper.Map<DeleteContainerModel>(request));
        var response = new CommonResponse<DeleteContainerResponse> 
            { Data = mapper.Map<DeleteContainerResponse>(container) };

        return response;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIdResponse>>> GetById([FromRoute] GetContainerByIdRequest request)
    {
        var container = await containerService.GetById(mapper.Map<GetContainerByIdModel>(request));
        var response = new CommonResponse<GetContainerByIdResponse>
            { Data = mapper.Map<GetContainerByIdResponse>(container) };

        return response;
    }
    
    
    [HttpGet("iso-numbers/{isoNumber}")]
    public async Task<ActionResult<CommonResponse<GetContainerByIsoResponse>>> GetByIso(
        [FromRoute] GetContainerByIsoRequest request)
    {
        var container = await containerService.GetByIso(
            mapper.Map<GetContainerByIsoModel>(request));
        var response = new CommonResponse<GetContainerByIsoResponse>
            { Data = mapper.Map<GetContainerByIsoResponse>(container) };
        
        return response;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetContainersByTypeIdResponse>>> GetByTypeId(
        GetContainersByTypeIdRequest request)
    {
        // todo: pagination from query parameters
        var containers = await containerService
            .GetByTypeId(mapper.Map<GetContainersByTypeIdModel>(request));
        var response = new CommonResponse<GetContainersByTypeIdResponse>
        {
            Data = new GetContainersByTypeIdResponse
                { Containers = mapper.Map<List<ContainerApiModel>>(containers) }
        };
        
        return response;
    }
}