namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class CampaignConfiguration : IEntityTypeConfiguration<Campaigns>
{
    public void Configure(EntityTypeBuilder<Campaigns> builder)
    {
        builder.ToTable(TableNames.Campaing);
        builder.HasKey(c => c.Id);
    }
}
