namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class Log : IEntityTypeConfiguration<Logs>
{
    public void Configure(EntityTypeBuilder<Logs> builder)
    {
        builder.ToTable(TableNames.Logs);
        builder.HasKey(t => t.Id);
    }
}
