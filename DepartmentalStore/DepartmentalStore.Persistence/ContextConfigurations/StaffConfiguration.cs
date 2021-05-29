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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Role).WithMany(r => r.Staffs).HasForeignKey(s => s.RoleId).IsRequired();
            builder.HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId).IsRequired();
            builder.HasOne(s => s.Gender).WithMany().HasForeignKey(s => s.GenderId).IsRequired();
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(30);
            builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.HasIndex(s => s.PhoneNumber).IsUnique();
            builder.Property(s => s.Email).IsRequired().HasMaxLength(30);
            builder.HasIndex(s => s.Email).IsUnique();
            builder.Property(s => s.Salary).IsRequired();
        }
    }
}