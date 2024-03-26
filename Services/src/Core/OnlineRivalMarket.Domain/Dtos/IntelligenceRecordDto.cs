using OnlineRivalMarket.Domain.Enums;
namespace OnlineRivalMarket.Domain.Dtos
{
    public  class IntelligenceRecordDto
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CompetitorsId { get; set; }
        public string? CompetitorsesName { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandId { get; set; }
        public string? BrandName { get; set; }
        public int IntelligenceType { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } 
        public string? Location { get; set; } 
        public int? Region { get; set; } 
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
}
