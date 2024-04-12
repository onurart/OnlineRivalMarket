using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Domain.Dtos.HomeTopDto
{
    public class HomeTopCampaignDto
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }

        public string? CompetitorId { get; set; }
        public string? CompetitorsesName { get; set; }

        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string? BrandId { get; set; }
        public string? BrandName { get; set; }



        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
