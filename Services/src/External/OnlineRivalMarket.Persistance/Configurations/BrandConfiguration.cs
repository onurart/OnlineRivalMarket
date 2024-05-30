namespace OnlineRivalMarket.Persistance.Configurations;

public sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(p=>p.Name).HasMaxLength(200);
        builder.ToTable(TableNames.Brand);
        builder.HasKey(x => x.Id);
    }
}
