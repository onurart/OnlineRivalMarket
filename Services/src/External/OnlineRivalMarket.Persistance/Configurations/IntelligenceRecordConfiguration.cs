namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class IntelligenceRecordConfiguration : IEntityTypeConfiguration<IntelligenceRecord>
{
    public void Configure(EntityTypeBuilder<IntelligenceRecord> builder)
    {
        builder.ToTable(TableNames.IntelligenceRecord);
        builder.HasKey(x => x.Id); 
    }
}
