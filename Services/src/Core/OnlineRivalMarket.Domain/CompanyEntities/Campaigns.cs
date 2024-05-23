namespace OnlineRivalMarket.Domain.CompanyEntities;
public class Campaigns : Entity
{
    [ForeignKey(nameof(CompetitorId))]
    public string? CompetitorId { get; set; }
    public Competitor? Competitor { get; set; }
    [ForeignKey(nameof(ProductId))]
    public string? ProductId { get; set; }
    public Product? Product { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    public string? UserLastName { get; set; }
    public ICollection<CampaingImagesFile>? CampaingImagesFiles { get; set; }
}
