namespace OnlineRivalMarket.Domain.CompanyEntities;
public class Product : Entity
{
    public string? ProductCode { get; set; }
    public string? ProducerCode { get; set; }
    public string? ProductName { get; set; }

    public string? VehicleTypeId { get; set; }
    public VehicleType? VehicleType { get; set; }

    public string? VehicleGroupId { get; set; }
    public VehicleGroup? VehicleGrup { get; set; }


    public string? CategoryId { get; set; }
    public Category? Category { get; set; }


    public string? BrandId { get; set; }
    public Brand? Brand { get; set; }

}
