using OnlineRivalMarket.Domain.Abstractions;
namespace OnlineRivalMarket.Domain.CompanyEntities;
public class Campaigns : Entity
{
    public string? CompetitorsId { get; set; }
    public string? BrandId { get; set; }
    public string? CategoryId { get; set; }
    
    
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
   
    public Competitorses? Competitors { get; set; }
    public Brand? Brand { get; set; }
    public Category? Category { get; set; }
}
