namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TableNames.Product); builder.HasKey(p => p.Id);
    }
}
