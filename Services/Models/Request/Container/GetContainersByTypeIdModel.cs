namespace Services.Models.Request.Container;

public class GetContainersByTypeIdModel
{
    public int TypeId { get; set; }
    
    public int Page { get; set; }
    
    public int PageSize { get; set; }
}