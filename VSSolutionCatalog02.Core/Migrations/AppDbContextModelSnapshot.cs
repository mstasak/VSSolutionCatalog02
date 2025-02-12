﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VSSolutionCatalog02.Core.Models;

#nullable disable

namespace VSSolutionCatalog02.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VSSolutionCatalog02.Core.Models.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Disposition")
                        .HasColumnType("text")
                        .HasColumnName("disposition");

                    b.Property<string>("Language")
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<string>("RelocateTo")
                        .HasColumnType("text")
                        .HasColumnName("relocateto");

                    b.Property<string>("Runtime")
                        .HasColumnType("text")
                        .HasColumnName("runtime");

                    b.Property<int?>("Size")
                        .HasColumnType("integer")
                        .HasColumnName("size");

                    b.Property<DateTime?>("SlnCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("slncreated");

                    b.Property<DateTime?>("SlnModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("slnmodified");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_solutions");

                    b.ToTable("solutions");
                });
#pragma warning restore 612, 618
        }
    }
}
