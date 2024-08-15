using Services.Models.Request.Type;
using Services.Models.Response.Type;

namespace Services.Services.Interfaces;

public interface ITypeService
{
    Task<int> Add(CreateTypeModel model);

    Task<TypeModel> Update(UpdateTypeModel model);

    Task<TypeModel> Delete(DeleteTypeModel model);

    Task<TypeModel> GetById(GetTypeByIdModel model);

    Task<List<TypeModel>> GetAll(GetAllTypesModel model);
}