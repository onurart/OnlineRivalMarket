namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class ImagesFileConfiguration : IEntityTypeConfiguration<ImagesFile>
{
    public void Configure(EntityTypeBuilder<ImagesFile> builder)
    {
        builder.ToTable(TableNames.ImagesFile);
        builder.HasKey(x => x.Id);
    }
}
