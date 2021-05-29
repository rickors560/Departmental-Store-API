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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId).IsRequired();
            builder.HasMany(s => s.ProductSuppliers).WithOne(ps => ps.Supplier);
            builder.HasOne(s => s.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.Property(s => s.Email).IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();
        }
    }
}