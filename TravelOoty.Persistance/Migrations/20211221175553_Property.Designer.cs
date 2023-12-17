﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelOoty.Persistance;

namespace TravelOoty.Persistance.Migrations
{
    [DbContext(typeof(TravelOotyDbContext))]
    [Migration("20211221175553_Property")]
    partial class Property
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelOoty.Domain.Entities.Amenities", b =>
                {
                    b.Property<int>("AmenitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AmenitiesId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            AmenitiesId = 1,
                            Name = "Parking"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = new Guid("cdccea0e-241b-4471-bca3-df01a5157940"),
                            Name = "Shaaniya"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.HotelCategory", b =>
                {
                    b.Property<int>("HotelCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelCategoryId");

                    b.ToTable("HotelCategory");

                    b.HasData(
                        new
                        {
                            HotelCategoryId = 1,
                            Name = "Classic"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.Property<int>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.HasKey("PropertyID");

                    b.HasIndex("AmenitiesId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            PropertyID = 1,
                            Address = "Coimbatore",
                            AmenitiesId = 1,
                            Location = "Coimbatore II",
                            Name = "Shanniya Estate",
                            PackageName = "Family",
                            PropertierName = "Shanniya",
                            PropertyTypeId = 1
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.PropertyType", b =>
                {
                    b.Property<int>("PropertyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyTypeId");

                    b.ToTable("PropertyTypes");

                    b.HasData(
                        new
                        {
                            PropertyTypeId = 1,
                            Name = "Hotel"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacility", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomFacilityId");

                    b.ToTable("RoomFacility");

                    b.HasData(
                        new
                        {
                            RoomFacilityId = 1,
                            Name = "Heater"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Amenities", "Amenities")
                        .WithMany()
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("PropertyType");
                });
#pragma warning restore 612, 618
        }
    }
}
