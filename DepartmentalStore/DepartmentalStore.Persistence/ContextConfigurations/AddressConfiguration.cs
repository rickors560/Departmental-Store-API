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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.AddressLine1).IsRequired().HasMaxLength(60);
            builder.Property(a => a.AddressLine2).HasMaxLength(60);
            builder.Property(a => a.City).IsRequired().HasMaxLength(30);
            builder.Property(a => a.State).IsRequired().HasMaxLength(30);
            builder.Property(a => a.Pincode).IsRequired().HasMaxLength(10);
        }
    }
}