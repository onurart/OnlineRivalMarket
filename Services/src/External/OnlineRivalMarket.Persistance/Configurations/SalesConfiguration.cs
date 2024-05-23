namespace OnlineRivalMarket.Persistance.Configurations;
public class SalesConfiguration : IEntityTypeConfiguration<Sales>
{
    public void Configure(EntityTypeBuilder<Sales> builder)
    {
        builder.ToTable(TableNames.Sales);
        builder.HasKey(s => s.Id);
    }
}
