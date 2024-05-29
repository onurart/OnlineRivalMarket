using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
