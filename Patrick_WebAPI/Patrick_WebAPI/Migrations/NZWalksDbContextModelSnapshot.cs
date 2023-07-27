﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patrick_WebAPI.Data;

#nullable disable

namespace Patrick_WebAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    partial class NZWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Patrick_WebAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2c6f8cf-4b3b-467e-a329-6dba8ef8d789"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("3dd5832e-3486-48cf-b65f-dd1f437a06a1"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("d35708cd-7600-419a-ace8-108378ff52b3"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("Patrick_WebAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9151fc1-3927-48e9-a4c7-5d2761c8b629"),
                            Code = "VNS",
                            Name = "Varansi",
                            RegionImageUrl = "image-vns.jpg"
                        },
                        new
                        {
                            Id = new Guid("8b2171f2-5c23-4d75-93af-c6529ef2cbbf"),
                            Code = "DEL",
                            Name = "Delhi",
                            RegionImageUrl = "image-del.jpg"
                        },
                        new
                        {
                            Id = new Guid("fdd46876-4630-499c-93f8-8f02b55dc14b"),
                            Code = "CHEN",
                            Name = "Chennai",
                            RegionImageUrl = "image-Chennai.jpg"
                        },
                        new
                        {
                            Id = new Guid("4f892c30-4271-4817-8310-99d631f6c1cb"),
                            Code = "HYD",
                            Name = "Hydarabad",
                            RegionImageUrl = "image-hyd.jpg"
                        },
                        new
                        {
                            Id = new Guid("195c66f8-2f06-4afb-9db6-6cf646e18a67"),
                            Code = "MUM",
                            Name = "Mumbai",
                            RegionImageUrl = "image-mum.jpg"
                        },
                        new
                        {
                            Id = new Guid("e3ce7ea7-a5a3-4236-8160-7b076dc89026"),
                            Code = "GUM",
                            Name = "Gurugram",
                            RegionImageUrl = "image-Gurugram.jpg"
                        });
                });

            modelBuilder.Entity("Patrick_WebAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("Patrick_WebAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("Patrick_WebAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Patrick_WebAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
