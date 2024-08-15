namespace Services.Models.Response.Container;

public class ContainerModel
{
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }
    
    public string IsoNumber { get; set; }

    public int TypeId { get; set; }

    public bool IsEngaged { get; set; }
	
    public DateTime? EngagedUntil { get; set; }
}