using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Persistance.Constans;
namespace OnlineRivalMarket.Persistance.Configurations
{
    public class CompetitorsConfiguration : IEntityTypeConfiguration<Competitorses>
    {
        public void Configure(EntityTypeBuilder<Competitorses> builder)
        {
            builder.ToTable(TableNames.Competitors); builder.HasKey(t => t.Id);
        }
    }
}
