﻿// <auto-generated />
using System;
using Infrastructure.Context.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations.SecurityMigrations
{
    [DbContext(typeof(SecurityContext))]
    partial class SecurityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Entities.ValueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateOn")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int>("IdExample")
                        .HasColumnType("int");

                    b.Property<int>("precios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Valor", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}