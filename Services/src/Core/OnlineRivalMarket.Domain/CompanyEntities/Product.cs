using OnlineRivalMarket.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public class Product : Entity
    {
        public string? Name { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }


        [ForeignKey(nameof(BrandId))]
        public string? BrandId { get; set; }
        public Brand? Brand { get; set; }
        //public ICollection<IntelligenceRecord> IntelligenceRecords { get; set; }

    }
}
