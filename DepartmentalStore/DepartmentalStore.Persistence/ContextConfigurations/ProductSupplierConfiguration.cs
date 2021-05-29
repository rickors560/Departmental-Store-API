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
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.SupplierId });
            builder.HasOne(ps => ps.Product).WithMany(p => p.ProductSuppliers).HasForeignKey(ps => ps.ProductId);
            builder.HasOne(ps => ps.Supplier).WithMany(s => s.ProductSuppliers).HasForeignKey(ps => ps.SupplierId);
        }
    }
}