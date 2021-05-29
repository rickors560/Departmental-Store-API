﻿using DepartmentalStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.ContextConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasMany(r => r.Staffs).WithOne(s => s.Role);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(r => r.Name).IsUnique();
            builder.Property(r => r.Description).IsRequired().HasMaxLength(100);
        }
    }
}
