﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductApi.DbContext;

#nullable disable

namespace ProductApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230408105255_SeedProducts")]
    partial class SeedProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductApi.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryName = "Инструмент",
                            Description = "Строительный инструмент",
                            ImageUrl = "",
                            Name = "Молоток",
                            Price = 8.0
                        },
                        new
                        {
                            Id = 2L,
                            CategoryName = "Инструмент",
                            Description = "Строительный инструмент",
                            ImageUrl = "",
                            Name = "Отвертка",
                            Price = 5.0
                        },
                        new
                        {
                            Id = 3L,
                            CategoryName = "Кухня",
                            Description = "Кухонные приборы",
                            ImageUrl = "",
                            Name = "Посуда",
                            Price = 14.0
                        },
                        new
                        {
                            Id = 4L,
                            CategoryName = "Фрукты",
                            Description = "Еда",
                            ImageUrl = "",
                            Name = "Яблоко",
                            Price = 7.0
                        },
                        new
                        {
                            Id = 5L,
                            CategoryName = "Овощ",
                            Description = "Еда",
                            ImageUrl = "",
                            Name = "Огурец",
                            Price = 4.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}