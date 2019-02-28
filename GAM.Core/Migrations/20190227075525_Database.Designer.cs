﻿// <auto-generated />
using System;
using GAM.Core.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GAM.Core.Migrations
{
    [DbContext(typeof(SqlLocalContext))]
    [Migration("20190227075525_Database")]
    partial class Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GAM.Core.Models.DepartRoot.Depart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Departs");
                });

            modelBuilder.Entity("GAM.Core.Models.MenuRoot.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("PID");

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("GAM.Core.Models.RoleRoot.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GAM.Core.Models.RoleRoot.RoleMenu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MenuID");

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.Property<int?>("RoleID");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("GAM.Core.Models.UserRoot.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("DepartID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<bool>("IsEnable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("DepartID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GAM.Core.Models.UserRoot.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Remarks")
                        .HasMaxLength(100);

                    b.Property<int?>("RoleID");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("GAM.Core.Models.RoleRoot.RoleMenu", b =>
                {
                    b.HasOne("GAM.Core.Models.MenuRoot.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuID");

                    b.HasOne("GAM.Core.Models.RoleRoot.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("GAM.Core.Models.UserRoot.User", b =>
                {
                    b.HasOne("GAM.Core.Models.DepartRoot.Depart", "Depart")
                        .WithMany("Users")
                        .HasForeignKey("DepartID");
                });

            modelBuilder.Entity("GAM.Core.Models.UserRoot.UserRole", b =>
                {
                    b.HasOne("GAM.Core.Models.RoleRoot.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.HasOne("GAM.Core.Models.UserRoot.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
