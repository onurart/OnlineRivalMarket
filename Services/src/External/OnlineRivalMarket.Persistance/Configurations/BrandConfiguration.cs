namespace OnlineRivalMarket.Persistance.Configurations;

public sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(TableNames.Brand);
        builder.HasKey(x => x.Id);
    }
}
