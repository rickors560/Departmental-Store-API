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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.ProductCategories).WithOne(pc => pc.Category);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property(c => c.ShortCode).IsRequired().HasMaxLength(4);
            builder.HasIndex(c => c.ShortCode).IsUnique();
        }
    }
}