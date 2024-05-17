using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Persistance.Constans;
namespace OnlineRivalMarket.Persistance.Configurations
{
    public sealed class ImagesFileConfiguration : IEntityTypeConfiguration<ImagesFile>
    {
        public void Configure(EntityTypeBuilder<ImagesFile> builder)
        {
            builder.ToTable(TableNames.ImagesFile);
            builder.HasKey(x => x.Id);
        }
    }
}
