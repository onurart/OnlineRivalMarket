namespace OnlineRivalMarket.Persistance.Configurations;
public class ForeignCurrencyConfigurations : IEntityTypeConfiguration<ForeignCurrency>
{
    public void Configure(EntityTypeBuilder<ForeignCurrency> builder)
    {
        builder.ToTable(TableNames.ForeignCurrency);
        builder.HasKey(t => t.Id);
    }
}
