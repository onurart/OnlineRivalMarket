namespace OnlineRivalMarket.Domain.CompanyEntities;
public class IntelligenceRecord : Entity
{
    public string? CompetitorId { get; set; }
    public Competitor? Competitor { get; set; }

    public string? ProductId { get; set; }
    public Product? Product { get; set; }


    public string? Description { get; set; }
    public decimal? MCurrency { get; set; }
    public decimal? RakipCurrency { get; set; }
    public int RowNo { get; set; }


    public string? ForeignCurrencyId { get; set; }
    public ForeignCurrency? ForeignCurrency { get; set; }


    public string? UserId { get; set; }
    public string? UserLastName { get; set; }
    public ICollection<ImagesFile>? IntelligenceRecordFiles { get; set; }

}
