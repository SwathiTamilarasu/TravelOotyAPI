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
    [Migration("20220218022053_RoomsEntity")]
    partial class RoomsEntity
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
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(9422),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(9426),
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
                            HotelId = new Guid("489c65d4-2a23-4383-9793-210690cf85ac"),
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
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(902),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(906),
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

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TotalRooms")
                        .HasColumnType("int");

                    b.HasKey("PropertyID");

                    b.HasIndex("AmenitiesId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
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
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(7200),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(8004),
                            Name = "Hotel"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomCategory", b =>
                {
                    b.Property<int>("RoomCategoryId")
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

                    b.HasKey("RoomCategoryId");

                    b.ToTable("RoomsCategory");

                    b.HasData(
                        new
                        {
                            RoomCategoryId = 1,
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4721),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4724),
                            Name = "Heater"
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
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(2039),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(2043),
                            Name = "Heater"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacilityLink", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomFacilityId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomFacilityLink");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Rooms", b =>
                {
                    b.Property<int>("RoomId")
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

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<string>("RegularPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialPrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("PropertyID");

                    b.HasIndex("RoomCategoryId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            CreatedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3566),
                            LastModifiedDate = new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3569),
                            Name = "Big Boss",
                            PropertyID = 0,
                            RegularPrice = "5000",
                            RoomCategoryId = 0,
                            SpecialPrice = "3000"
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

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacilityLink", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.RoomFacility", "RoomFacility")
                        .WithMany("FacilityJoins")
                        .HasForeignKey("RoomFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.Rooms", "Rooms")
                        .WithMany("FacilityJoins")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomFacility");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Rooms", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Property", "Property")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.RoomCategory", "RoomCategory")
                        .WithMany()
                        .HasForeignKey("RoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("RoomCategory");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacility", b =>
                {
                    b.Navigation("FacilityJoins");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Rooms", b =>
                {
                    b.Navigation("FacilityJoins");
                });
#pragma warning restore 612, 618
        }
    }
}
