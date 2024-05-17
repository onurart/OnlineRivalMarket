using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Persistance.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Configurations
{
    internal class ForeignCurrencyConfigurations : IEntityTypeConfiguration<ForeignCurrency>
    {
        public void Configure(EntityTypeBuilder<ForeignCurrency> builder)
        {
            builder.ToTable(TableNames.ForeignCurrency);
            builder.HasKey(t => t.Id);
        }
    }
}
