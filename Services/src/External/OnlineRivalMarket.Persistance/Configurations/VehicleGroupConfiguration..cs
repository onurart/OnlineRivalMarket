namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class VehicleGroupConfiguration : IEntityTypeConfiguration<VehicleGroup>
{
    public void Configure(EntityTypeBuilder<VehicleGroup> builder)
    {
        builder.ToTable(TableNames.VehicleGroup);
        builder.HasKey(t => t.Id);
    }
}
