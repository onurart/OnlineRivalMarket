namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable(TableNames.VehicleType);
        builder.HasKey(t => t.Id);
    }
}


