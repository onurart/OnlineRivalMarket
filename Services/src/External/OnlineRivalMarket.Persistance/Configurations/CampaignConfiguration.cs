namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class CampaignConfiguration : IEntityTypeConfiguration<Campaigns>
{
    public void Configure(EntityTypeBuilder<Campaigns> builder)
    {
        builder.ToTable(TableNames.Campaing);
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.CampaingImagesFiles).WithOne().HasForeignKey(c => c.CampaignsId);

        builder.HasOne(c => c.Competitor).WithMany().HasForeignKey(c => c.CompetitorId);
        builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId);

        builder.Property(c => c.Description).HasMaxLength(250);
        builder.Property(c => c.UserLastName).IsRequired(false);
        builder.Property(c => c.StartTime).IsRequired(false);
        builder.Property(c => c.EndTime).IsRequired(false);
        builder.Property(c => c.UserId).IsRequired(false);
        builder.Property(c => c.RowNo).IsRequired(false);
    }
}


