using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Dtos.Campaing
{
    public class GetByCampaingProductIntelligenceRecord
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CompetitorId { get; set; }
        public string? CompetitorName { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandId { get; set; }
        public string? BrandName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? RowNo { get; set; }

        public string? VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; }
        public string? VehicleGroupId { get; set; }
        public string? VehicleGroupName { get; set; }
        public string? Description { get; set; }
    }
}
