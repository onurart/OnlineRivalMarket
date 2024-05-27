namespace OnlineRivalMarket.Domain.Dtos.FieldInformationDtos
{
    public class CompetitorIntelligenceRecordDto
    {
        public string Id { get; set; }
        public string CompetitorId { get; set; }
        public string CompetitorName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RowNo { get; set; }
    }
}
