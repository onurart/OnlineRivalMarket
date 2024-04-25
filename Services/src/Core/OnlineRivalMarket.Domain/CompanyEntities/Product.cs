using OnlineRivalMarket.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public class Product : Entity
    {


        public string? ProductCode { get; set; }
        public string? ProducerCode { get; set; }
        public string? ProductName { get; set; }



        [ForeignKey(nameof(VehicleTypeId))]
        public string? VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }

        [ForeignKey(nameof(VehicleGroupId))]
        public string? VehicleGroupId { get; set; }
        public VehicleGroup? VehicleGrup { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }


        [ForeignKey(nameof(BrandId))]
        public string? BrandId { get; set; }
        public Brand? Brand { get; set; }

    }
}
