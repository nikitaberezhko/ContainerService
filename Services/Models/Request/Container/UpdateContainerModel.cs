namespace Services.Models.Request.Container;

public class UpdateContainerModel
{
    public Guid Id { get; set; }
    
    public string IsoNumber { get; set; }
    
    public int TypeId { get; set; }
    
    public bool IsEngaged { get; set; }
    
    public DateTime? EngagedUntil { get; set; }
}