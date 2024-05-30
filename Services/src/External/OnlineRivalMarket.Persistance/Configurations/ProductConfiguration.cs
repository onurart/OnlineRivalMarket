namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TableNames.Product); builder.HasKey(p => p.Id);
        builder.Property(p => p.ProducerCode).HasMaxLength(200);
        builder.Property(p => p.ProductCode).HasMaxLength(200);
        builder.Property(p => p.ProductName).HasMaxLength(200);


        builder.HasOne(p => p.VehicleGrup).WithMany().HasForeignKey(p => p.VehicleGroupId);
        builder.HasOne(p => p.VehicleType).WithMany().HasForeignKey(p => p.VehicleTypeId);
           builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
        builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
    }
}
