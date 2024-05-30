namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class FieldInformationConfiguration : IEntityTypeConfiguration<FieldInformation>
{
    public void Configure(EntityTypeBuilder<FieldInformation> builder)
    {
        builder.ToTable(TableNames.FieldInformation);
        builder.HasKey(x => x.Id);

        builder.HasOne(f=>f.Competitor).WithMany().HasForeignKey(f => f.CompetitorId);


        builder.Property(f=>f.Description).HasMaxLength(250);
        builder.Property(f=>f.Title).HasMaxLength(200);
        builder.Property(f => f.RowNo).IsRequired(false);
    }
}
