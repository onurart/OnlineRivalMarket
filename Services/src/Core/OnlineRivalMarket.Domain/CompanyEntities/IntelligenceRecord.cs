//using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace OnlineRivalMarket.Domain.CompanyEntities;
public class IntelligenceRecord : Entity
{
    [ForeignKey(nameof(CompetitorId))]
    public string? CompetitorId { get; set; }
    public Competitor? Competitor { get; set; }

    [ForeignKey(nameof(ProductId))]
    public string? ProductId { get; set; }
    public Product? Product { get; set; }


    public string? Description { get; set; }
    public decimal? MCurrency { get; set; }
    public decimal? RakipCurrency { get; set; }


    [ForeignKey(nameof(ForeignCurrencyId))]
    public string? ForeignCurrencyId { get; set; }
    public ForeignCurrency? ForeignCurrency { get; set; }
    public string? UserId { get; set; }
    public string? UserLastName { get; set; }
    public ICollection<ImagesFile>? IntelligenceRecordFiles { get; set; }

}
