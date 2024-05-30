namespace OnlineRivalMarket.Persistance.Configurations
{
    public sealed class ClientIpAdress : IEntityTypeConfiguration<ClientIpAddresses>
    {
        public void Configure(EntityTypeBuilder<ClientIpAddresses> builder)
        {
            builder.ToTable(TableNames.ClientIpAddress);
            builder.HasKey(x => x.Id);
        }
    }
}
