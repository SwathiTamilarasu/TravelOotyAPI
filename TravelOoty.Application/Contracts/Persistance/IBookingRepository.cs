using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IBookingRepository: IAsyncRespository<Booking>
    {
        Task<List<BookingVM>> GetBookingList();

        Task<List<BookingVM>> GetBookingListByDate(int room, DateTime fromDate, DateTime toDate);
        Task<decimal> GetRoomRent(int roomId);
        Task<Booking> GetBookingListByIdAsync(int bookingId);
        Task<List<BookingVM>> GetBookingListByUserId(string userId);
        Task<List<BookingVM>> GetBookingListByByPropId(int propertyId);
        Task<Booking> GetBookingById(int bookingId);

    }
}
