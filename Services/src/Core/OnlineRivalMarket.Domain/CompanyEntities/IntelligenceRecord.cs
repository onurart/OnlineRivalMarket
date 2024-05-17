using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineRivalMarket.Domain.Abstractions;
using OnlineRivalMarket.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
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

    public ICollection<ImagesFile>? IntelligenceRecordFiles { get; set; }


    //public IntelligenceType? IntelligenceType { get; set; }
    //public Region? Region { get; set; }

    //public string? Location { get; set; }
    //public string? FieldFeedback { get; set; }
    //public string? Explanation { get; set; }
}
