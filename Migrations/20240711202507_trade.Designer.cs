﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240711202507_trade")]
    partial class trade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("api.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("LastDiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Purchase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("api.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("decimal(18,5)");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("ExitPrice")
                        .HasColumnType("decimal(18,5)");

                    b.Property<int>("PipSize")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal?>("StopLoss")
                        .HasColumnType("decimal(18,5)");

                    b.Property<decimal?>("TakeProfit")
                        .HasColumnType("decimal(18,5)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Trade");
                });

            modelBuilder.Entity("api.Models.Comment", b =>
                {
                    b.HasOne("api.Models.Stock", null)
                        .WithMany("Comments")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Trade", b =>
                {
                    b.HasOne("api.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("api.Models.Stock", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
