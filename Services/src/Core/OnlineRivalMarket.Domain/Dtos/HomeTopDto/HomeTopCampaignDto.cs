namespace OnlineRivalMarket.Domain.Dtos.HomeTopDto
{
    public class HomeTopCampaignDto
    {
        public string? CompetitorsId { get; set; }
        public string? CompetitorName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string BrandId { get; set; }
        public string BrandName { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

}
}
