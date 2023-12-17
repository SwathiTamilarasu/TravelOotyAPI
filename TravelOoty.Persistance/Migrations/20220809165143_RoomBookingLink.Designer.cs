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
    [Migration("20220809165143_RoomBookingLink")]
    partial class RoomBookingLink
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
                            CreatedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(7162),
                            LastModifiedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(7166),
                            Name = "Parking"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConfirmEmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBookingExpired")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
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

                    b.HasKey("CityId");

                    b.ToTable("Cities");
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
                            HotelId = new Guid("bd213927-ad1e-42c4-979f-8e931d5a32fd"),
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
                            CreatedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(8501),
                            LastModifiedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(8504),
                            Name = "Classic"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.Property<int>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckInOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontDeskTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IfscCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TotalRooms")
                        .HasColumnType("int");

                    b.HasKey("PropertyID");

                    b.HasIndex("CityId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.PropertyAmenitiesLink", b =>
                {
                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AmenitiesId", "PropertyID");

                    b.HasIndex("PropertyID");

                    b.ToTable("PropertyAmenitiesLinks");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.PropertyImageDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertiesImages");
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
                            CreatedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(3571),
                            LastModifiedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(4970),
                            Name = "Hotel"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomBookingLink", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("BookingId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomBookingLink");
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
                            CreatedDate = new DateTime(2022, 8, 9, 16, 51, 42, 88, DateTimeKind.Utc).AddTicks(976),
                            LastModifiedDate = new DateTime(2022, 8, 9, 16, 51, 42, 88, DateTimeKind.Utc).AddTicks(979),
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
                            CreatedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(9741),
                            LastModifiedDate = new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(9745),
                            Name = "Heater"
                        });
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacilityLink", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomFacilityId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomFacilityLink");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomImageDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomImages");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Rooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<string>("CancellationPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Guests")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfRoomsCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<decimal>("RegularPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("SpecialPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RoomId");

                    b.HasIndex("PropertyID");

                    b.HasIndex("RoomCategoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.PropertyAmenitiesLink", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Amenities", "Amenities")
                        .WithMany("AmenitiesJoins")
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.Property", "Property")
                        .WithMany("AmenitiesJoins")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.PropertyImageDetails", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomBookingLink", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Booking", "Booking")
                        .WithMany("RoomBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelOoty.Domain.Entities.Rooms", "Rooms")
                        .WithMany("RoomBookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Rooms");
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

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomImageDetails", b =>
                {
                    b.HasOne("TravelOoty.Domain.Entities.Rooms", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
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

            modelBuilder.Entity("TravelOoty.Domain.Entities.Amenities", b =>
                {
                    b.Navigation("AmenitiesJoins");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Booking", b =>
                {
                    b.Navigation("RoomBookings");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Property", b =>
                {
                    b.Navigation("AmenitiesJoins");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.RoomFacility", b =>
                {
                    b.Navigation("FacilityJoins");
                });

            modelBuilder.Entity("TravelOoty.Domain.Entities.Rooms", b =>
                {
                    b.Navigation("FacilityJoins");

                    b.Navigation("RoomBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
