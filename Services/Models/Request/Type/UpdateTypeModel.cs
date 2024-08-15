namespace Services.Models.Request.Type;

public class UpdateTypeModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public double PricePerDay { get; set; }
}