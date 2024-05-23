namespace OnlineRivalMarket.Domain.CompanyEntities;
public class Sales : Entity
{
    public string? CompetitorId { get; set; }
    public string? BrandId { get; set; }
    public string? CategoryId { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Date { get; set; }
    public bool? IsCampaign { get; set; }
}
