﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Models;

namespace Tennis.DAL.Configuration
{
    public class RoleConfiguration : BaseEntityTypeConfiguration<Role>
    {
        public RoleConfiguration() : base("tbl") { }

        public override void Configure(EntityTypeBuilder<Role> e)
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Id).ValueGeneratedOnAdd();

            e.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(20)");
            e.HasIndex(c => c.Name).IsUnique();

            e.HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Admin" }
            );

            base.Configure(e);
        }
    }
}
