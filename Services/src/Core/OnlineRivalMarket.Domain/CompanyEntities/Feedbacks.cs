namespace OnlineRivalMarket.Domain.CompanyEntities;
public class Feedbacks
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    [ForeignKey(nameof(CompetitorId))]
    public string? CompetitorId { get; set; }
    public Competitor? Competitorses { get; set; }
    public string? ImageUrl { get; set; }
}
