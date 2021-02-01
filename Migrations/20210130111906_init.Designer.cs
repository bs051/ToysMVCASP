﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToysMVCASP.Data;

namespace ToysMVCASP.Migrations
{
    [DbContext(typeof(ToysMVCASPContext))]
    [Migration("20210130111906_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToysMVCASP.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForGender")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ToysMVCASP.Models.Toy", b =>
                {
                    b.Property<int>("ToyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeGroup")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ToyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToyRating")
                        .HasColumnType("int");

                    b.HasKey("ToyId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Toy");
                });

            modelBuilder.Entity("ToysMVCASP.Models.ToyRel", b =>
                {
                    b.Property<int>("ToyRelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<int>("ToyId")
                        .HasColumnType("int");

                    b.Property<int>("ToyStoreId")
                        .HasColumnType("int");

                    b.HasKey("ToyRelId");

                    b.HasIndex("ToyId");

                    b.HasIndex("ToyStoreId");

                    b.ToTable("ToyRel");
                });

            modelBuilder.Entity("ToysMVCASP.Models.ToyStore", b =>
                {
                    b.Property<int>("ToyStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OpeningTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreNAme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToyStoreId");

                    b.ToTable("ToyStore");
                });

            modelBuilder.Entity("ToysMVCASP.Models.Toy", b =>
                {
                    b.HasOne("ToysMVCASP.Models.Category", "CategoryObj")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToysMVCASP.Models.ToyRel", b =>
                {
                    b.HasOne("ToysMVCASP.Models.Toy", "ToyObj")
                        .WithMany()
                        .HasForeignKey("ToyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToysMVCASP.Models.ToyStore", "ToyStoreObj")
                        .WithMany()
                        .HasForeignKey("ToyStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
