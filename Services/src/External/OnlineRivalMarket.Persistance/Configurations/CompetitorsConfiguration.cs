namespace OnlineRivalMarket.Persistance.Configurations;
public class CompetitorsConfiguration : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> builder)
    {
        builder.ToTable(TableNames.Competitors); builder.HasKey(t => t.Id);
    }
}
