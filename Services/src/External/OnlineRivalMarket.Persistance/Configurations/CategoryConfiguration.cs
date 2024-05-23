namespace OnlineRivalMarket.Persistance.Configurations;
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(TableNames.Category);
        builder.HasKey(t => t.Id);
    }
}
