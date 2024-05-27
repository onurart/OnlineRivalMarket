namespace OnlineRivalMarket.Domain.CompanyEntities;
public class FieldInformation : Entity
{
    public FieldInformation(){}
    public FieldInformation(string? competitorId, Competitor? competitor, string? description, string? title, string? userId)
    {CompetitorId = competitorId;Competitor = competitor;Description = description;Title = title;UserId = userId;}
    [ForeignKey(nameof(CompetitorId))]
    public string? CompetitorId { get; set; }
    public Competitor? Competitor { get; set; }
    public string? Description { get; set; }
    public int? RowNo { get; set; }
    public string? Title { get; set; }
    public string? UserId { get; set; }
    public string? UserLastName { get; set; }
    public ICollection<FieldInformationImagesFile> FieldInformationImagesFiles { get; set; }
}