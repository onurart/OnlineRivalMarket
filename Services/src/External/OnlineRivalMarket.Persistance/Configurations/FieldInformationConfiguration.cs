namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class FieldInformationConfiguration : IEntityTypeConfiguration<FieldInformation>
{
    public void Configure(EntityTypeBuilder<FieldInformation> builder)
    {
        builder.ToTable(TableNames.FieldInformation);
        builder.HasKey(x => x.Id);
    }
}
