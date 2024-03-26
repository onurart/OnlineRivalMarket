using OnlineRivalMarket.Domain.Abstractions;
using OnlineRivalMarket.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRivalMarket.Domain.CompanyEntities;
public class IntelligenceRecord : Entity
{
    [ForeignKey(nameof(CompetitorsId))]
    public string? CompetitorsId { get; set; }
    public Competitorses? Competitorses { get; set; }


    [ForeignKey(nameof(BrandId))]
    public string? BrandId { get; set; }
    public Brand? Brand { get; set; }



    [ForeignKey(nameof(CategoryId))]
    public string? CategoryId { get; set; }
    public Category? Category { get; set; }



    [ForeignKey(nameof(ProductId))]
    public string? ProductId { get; set; }
    public Product? Product { get; set; }

    public IntelligenceType? IntelligenceType { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Location { get; set; }
    public Region? Region { get; set; }
    public string? VehicleType { get; set; }
    public string? VehicleGroup { get; set; }
    public string? FieldFeedback { get; set; }
    public string? Explanation { get; set; }
    public decimal? CurrencyTl { get; set; }
    public decimal? CurrencyDolor { get; set; }
    public decimal? CurrencyEuro { get; set; }
    public decimal? RakipTl { get; set; }
    public decimal? RakipDolor { get; set; }
    public decimal? RakipEuro { get; set; }
}
