using DepartmentalStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.ContextConfigurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.HasOne(pc => pc.Product).WithMany(p => p.Prices).HasForeignKey(pc => pc.ProductId);
            builder.Property(pc => pc.CostPrice).IsRequired();
            builder.Property(pc => pc.SellingPrice).IsRequired();
            builder.Property(pc => pc.EffectiveDate).IsRequired();
        }
    }
}