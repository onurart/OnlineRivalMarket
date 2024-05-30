namespace OnlineRivalMarket.Domain.Dtos.Campaing.GetAllCampaing;

public class GetAllCampaingDto
{
    public string Id { get; set; }
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? CompetitorId { get; set; }
    public string? CompetitorName { get; set; }
    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? BrandId { get; set; }
    public string? BrandName { get; set; }
    public int RowNo { get; set; }
    public DateTime CreateDate { get; set; }
    public string UserId { get; set; }
    public string UserLastName { get; set; }
    public IEnumerable<string> ImageFiles { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Description { get; set; }
}
