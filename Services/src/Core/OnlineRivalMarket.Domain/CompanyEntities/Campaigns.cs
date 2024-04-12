using OnlineRivalMarket.Domain.Abstractions;
using OnlineRivalMarket.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
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
    public string? ImageUrl { get; set; }
   

   
}
