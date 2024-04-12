using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Persistance.Constans;
namespace OnlineRivalMarket.Persistance.Configurations
{
    public class CompetitorsConfiguration : IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            builder.ToTable(TableNames.Competitors); builder.HasKey(t => t.Id);
        }
    }
}
