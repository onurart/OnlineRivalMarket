namespace OnlineRivalMarket.Domain.Dtos.IntelligenceDto;
public  class IntelligenceByIdDto
{
    public string Id { get; set; }
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }

    public string? CompetitorId { get; set; }
    public string? CompetitorName { get; set; }

    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public string? BrandId { get; set; }
    public string? BrandName { get; set; }

    public IEnumerable<string> ImageFiles { get; set; }
    public DateTime CreateDate { get; set; }


    public string? VehicleTypeId { get; set; }
    public string? VehicleTypeName { get; set; }

    public string? VehicleGroupId { get; set; }
    public string? VehicleGroupName { get; set; }

    public string? Description { get; set; }

    public string? UserId { get; set; }
    public string? UserLastName { get; set; }

    public decimal? MCurrency { get; set; }
    public decimal? RakipCurrency { get; set; }
    public string? ForeignCurrencyId { get; set; }
    public string? ForeignCurrencyName { get; set; }
}
