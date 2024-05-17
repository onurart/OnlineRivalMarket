using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Dtos.Product
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProducerCode { get; set; }
        public string? ProductName { get; set; }




        public string? VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; }


        public string? VehicleGroupId { get; set; }
        public string? VehicleGroupName { get; set; }
        public DateTime CreateDate { get; set; }

        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
