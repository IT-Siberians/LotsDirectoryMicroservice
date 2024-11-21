﻿// <auto-generated />
using System;
using LotDesignerMicroservice.Infrastructure.EfRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118231545_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LotCardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("LotCardId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.LotCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTime?>("LastModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PriceStep")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("RepurchasePrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("TradeDuration")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("LotsCards");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.Image", b =>
                {
                    b.HasOne("LotDesignerMicroservice.Domain.Entities.Entities.LotCard", "LotCard")
                        .WithMany("Images")
                        .HasForeignKey("LotCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LotCard");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.LotCard", b =>
                {
                    b.HasOne("LotDesignerMicroservice.Domain.Entities.Entities.Seller", "Seller")
                        .WithMany("_lotCards")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.LotCard", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("LotDesignerMicroservice.Domain.Entities.Entities.Seller", b =>
                {
                    b.Navigation("_lotCards");
                });
#pragma warning restore 612, 618
        }
    }
}
