
namespace OnlineRivalMarket.Domain.Dtos.FieldInformationDtos
{
    public  class FieldInformationsesDto
    {
        public string Id { get; set; }
        public string CompetitorId { get; set; }
        public string CompetitorName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> ImageFiles { get; set; }


    }
}
