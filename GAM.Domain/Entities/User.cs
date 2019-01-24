﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GAM.Domain.IComm;

namespace GAM.Domain.Entities
{
    public class User : IAggregareRoot
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public string Remarks { get; set; }
        public int CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDeleted { get; set; }

        //导航属性
        public virtual Department Department { get; set; } = new Department();
        public virtual IQueryable<UserRole> UserRoles { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.HasKey(e=>e.ID);
            b.Property(e=>e.Account).IsRequired().HasMaxLength(30);
            b.Property(e=>e.Password).IsRequired().HasMaxLength(30);
            b.Property(e=>e.Name).IsRequired().HasMaxLength(10);
            b.Property(e=>e.EMail).IsRequired().HasMaxLength(80);
            b.Property(e=>e.MobileNumber).IsRequired().HasMaxLength(11);
            b.Property(e=>e.Remarks).HasMaxLength(100);
            b.Property(e=>e.CreateUser).IsRequired();
            b.Property(e=>e.CreateTime).HasDefaultValue(DateTime.Now);
            b.Property(e=>e.LastLoginTime).IsRequired().HasColumnType("DateTime");
            b.Property(e=>e.IsDeleted).HasDefaultValue(false);
        }
    }
}
