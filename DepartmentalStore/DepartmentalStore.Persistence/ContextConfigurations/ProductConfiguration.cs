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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.ProductCategories).WithOne(pc => pc.Product);
            builder.HasMany(p => p.Prices).WithOne(pc => pc.Product);
            builder.HasOne(p => p.Inventory).WithOne(i => i.Product);
            builder.HasMany(p => p.ProductSuppliers).WithOne(ps => ps.Product);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.ShortCode).IsRequired().HasMaxLength(4);
            builder.HasIndex(p => p.ShortCode).IsUnique();
            builder.Property(p => p.Manufacturer).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Quantity).IsRequired();
        }
    }
}