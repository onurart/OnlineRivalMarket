using OnlineRivalMarket.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRivalMarket.Domain.CompanyEntities;
public class FieldInformation : Entity
{
    [ForeignKey(nameof(CompetitorId))]
    public string? CompetitorId { get; set; }
    public Competitor? Competitor { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public ICollection<FieldInformationImagesFile> FieldInformationImagesFiles { get; set; }
}