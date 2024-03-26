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
    public sealed class FieldInformationConfiguration : IEntityTypeConfiguration<FieldInformation>
    {
        public void Configure(EntityTypeBuilder<FieldInformation> builder)
        {
            builder.ToTable(TableNames.FieldInformation);
            builder.HasKey(x => x.Id);
        }
    }
}
