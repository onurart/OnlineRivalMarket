using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Persistance.Constans;
namespace OnlineRivalMarket.Persistance.Configurations
{
    public sealed class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable(TableNames.VehicleType);
            builder.HasKey(t => t.Id);
        }
    }
}


