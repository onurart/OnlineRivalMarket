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
    public sealed class VehicleGroupConfiguration : IEntityTypeConfiguration<VehicleGroup>
    {
        public void Configure(EntityTypeBuilder<VehicleGroup> builder)
        {
            builder.ToTable(TableNames.VehicleGroup);
            builder.HasKey(t => t.Id);
        }
    }
}
