using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Persistance.Repositories;

namespace TravelOoty.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelOotyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TravelOotyConnectionString")));
            services.AddScoped(typeof(IAsyncRespository<>), typeof(BaseRepository<>));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();
            services.AddScoped<IHotelCategoryRepository, HotelCategoryRepository>();
            services.AddScoped<IRoomFacilityRepository, RoomFacilityRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICityRepository,CityRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomImageRepository, RoomImageRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IBookingRepository,BookingRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
            return services;

        }
    }
}
