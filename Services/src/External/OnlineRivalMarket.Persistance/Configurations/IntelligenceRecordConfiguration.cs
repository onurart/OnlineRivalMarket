using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    public sealed class IntelligenceRecordConfiguration : IEntityTypeConfiguration<IntelligenceRecord>
    {
        public void Configure(EntityTypeBuilder<IntelligenceRecord> builder)
        {
            builder.ToTable(TableNames.IntelligenceRecord);
            builder.HasKey(x => x.Id); 
        }
    }
}
