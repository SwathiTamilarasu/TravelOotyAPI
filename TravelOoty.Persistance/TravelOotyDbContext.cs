using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Domain.Entities;
using TravelOoty.Domain.Common;
using TravelOoty.Application.Contracts;

namespace TravelOoty.Persistance
{
    public class TravelOotyDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        public TravelOotyDbContext(DbContextOptions<TravelOotyDbContext> options) : base(options)
        {

        }
        public TravelOotyDbContext(DbContextOptions<TravelOotyDbContext> options, ILoggedInUserService loggedInUserService)
     : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RoomCategory> RoomsCategory { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<PropertyAmenitiesLink> PropertyAmenitiesLinks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<RoomImageDetails> RoomImages { get; set; }       
        public DbSet<PropertyImageDetails> PropertiesImages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomBookingLink> RoomBookingLinks { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        //    public DbSet<RoomFacility> RoomFacilities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelOotyDbContext).Assembly);

            modelBuilder.Entity<Hotel>().HasData(new Hotel { HotelId = Guid.NewGuid(),Name="Shaaniya" });
            modelBuilder.Entity<PropertyType>(b =>
            {
                b.HasKey(e => e.PropertyTypeId);
                b.Property(e => e.PropertyTypeId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Amenities>(b =>
            {
                b.HasKey(e => e.AmenitiesId);
                b.Property(e => e.AmenitiesId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<HotelCategory>(b =>
            {
                b.HasKey(e => e.HotelCategoryId);
                b.Property(e => e.HotelCategoryId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<RoomFacility>(b =>
            {
                b.HasKey(e => e.RoomFacilityId);
                b.Property(e => e.RoomFacilityId).ValueGeneratedOnAdd();
                
            });
            modelBuilder.Entity<RoomCategory>(b =>
            {
                b.HasKey(e => e.RoomCategoryId);
                b.Property(e => e.RoomCategoryId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RoomImageDetails>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<PropertyImageDetails>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<City>(b =>
            {
                b.HasKey(e => e.CityId);
                b.Property(e => e.CityId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Property>(b =>
            {
                b.HasKey(e => e.PropertyID);
                b.Property(e => e.PropertyID).ValueGeneratedOnAdd();                  
            });
            modelBuilder.Entity<Booking>(b =>
            {
                b.HasKey(e => e.BookingId);
                b.Property(e => e.BookingId).ValueGeneratedOnAdd();              
            });
            modelBuilder.Entity<PaymentDetails>(b =>
            {
                b.HasKey(e => e.PaymentDetailsId);
                b.Property(e => e.PaymentDetailsId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<RoomBookingLink>().HasKey(t => new { t.BookingId, t.RoomId });
            modelBuilder.Entity<RoomBookingLink>().HasOne(p => p.Booking).WithMany(r => r.RoomBookings).HasForeignKey(e => e.BookingId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RoomBookingLink>().HasOne(p => p.Rooms).WithMany(r => r.RoomBookings).HasForeignKey(e => e.RoomId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAmenitiesLink>().HasKey(t => new { t.AmenitiesId, t.PropertyID });
            modelBuilder.Entity<PropertyAmenitiesLink>().HasOne(p => p.Property).WithMany(r => r.AmenitiesJoins).HasForeignKey(e => e.PropertyID);
            modelBuilder.Entity<PropertyAmenitiesLink>().HasOne(p => p.Amenities).WithMany(r => r.AmenitiesJoins).HasForeignKey(e => e.AmenitiesId);
    

            modelBuilder.Entity<Rooms>(b =>
            {
                b.HasKey(e => e.RoomId);
                b.Property(e => e.RoomId).ValueGeneratedOnAdd();
                b.HasOne(e => e.Property).WithMany(e => e.Rooms).HasForeignKey(e=>e.PropertyID);          
                
            });
            modelBuilder.Entity<RoomFacilityLink>().HasKey(t=>new {t.RoomFacilityId,t.RoomId});
            modelBuilder.Entity<RoomFacilityLink>().HasOne(p => p.RoomFacility).WithMany(r => r.FacilityJoins).HasForeignKey(e => e.RoomFacilityId);
            modelBuilder.Entity<RoomFacilityLink>().HasOne(p => p.Rooms).WithMany(r => r.FacilityJoins).HasForeignKey(e => e.RoomId);

            modelBuilder.Entity<PropertyType>().HasData(new PropertyType { PropertyTypeId = 1, Name = "Hotel" ,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<Amenities>().HasData(new Amenities { AmenitiesId = 1, Name = "Parking",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<HotelCategory>().HasData(new HotelCategory { HotelCategoryId = 1, Name = "Classic" ,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<RoomFacility>().HasData(new RoomFacility { RoomFacilityId = 1, Name = "Heater",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
            });
            //modelBuilder.Entity<City>().HasData(new City
            //{
            //    CityId = 1,
            //    Name = "Ooty",
            //    CreatedDate = DateTime.UtcNow,
            //    LastModifiedDate = DateTime.UtcNow,
            //});
            //modelBuilder.Entity<Rooms>().HasData(new Rooms
            //{
            //    RoomId = 1,
            //    Name = "Big Boss",                             
            //    RegularPrice = "5000",
            //    SpecialPrice="3000",                
            //    CreatedDate = DateTime.UtcNow,
            //    LastModifiedDate = DateTime.UtcNow,
            //}); 

            modelBuilder.Entity<RoomCategory>().HasData(new RoomCategory
            {
                RoomCategoryId = 1,
                Name = "Heater",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
            });
       
            //modelBuilder.Entity<Property>().HasData(new Property 
            //{
            //    PropertyID = 1, 
            //    Name = "Shanniya Estate",
            //    Address="Coimbatore",
            //    PropertierName="Shanniya",
            //    Location="Coimbatore II",
            //    PackageName="Family",
            //    PropertyTypeId=1,
            //    AmenitiesId=1,
            //    CreatedDate=DateTime.UtcNow,
            //    LastModifiedDate=DateTime.UtcNow,
            //    //Rooms= new List<Rooms> { new Domain.Entities.Rooms {  RoomId = 2,
            //    //            Name = "Test Room",
            //    //            RoomFacility = new List<RoomFacility> { new RoomFacility {RoomFacilityId=2,Name= "Heater" },
            //    //                new RoomFacility { RoomFacilityId=3,Name= "Parking" } },
            //    //            Property = new Property { PropertyID = 1 },
            //    //            RegularPrice = "4000",
            //    //            SpecialPrice="3200",
            //    //            RoomCategory=new RoomCategory { RoomCategoryId = 2},
            //    //            CreatedDate = DateTime.UtcNow,
            //    //            LastModifiedDate = DateTime.UtcNow,} 
            //    //}
            //});

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
