namespace BusModels;

public class OrderDeletedMessage
{
    public List<Guid> ContainerIds { get; set; }
    
    public Guid OrderId { get; set; }
}