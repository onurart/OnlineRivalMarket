namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class IntelligenceRecordConfiguration : IEntityTypeConfiguration<IntelligenceRecord>
{
    public void Configure(EntityTypeBuilder<IntelligenceRecord> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable(TableNames.IntelligenceRecord);
        builder.HasOne(x => x.Competitor).WithMany().HasForeignKey(x => x.CompetitorId);
        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.ForeignCurrency).WithMany().HasForeignKey(x => x.ForeignCurrencyId);

        builder.Property(x => x.Description).HasMaxLength(250);
        builder.Property(x => x.RakipCurrency).IsRequired();
        builder.Property(x => x.MCurrency).IsRequired();
        builder.Property(x => x.RowNo).IsRequired();

    }
}
