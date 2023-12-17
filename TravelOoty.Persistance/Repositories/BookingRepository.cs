using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class BookingRepository:BaseRepository<Booking>, IBookingRepository
    {
        private readonly IMapper _mapper;
        public BookingRepository(TravelOotyDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public async Task<List<BookingVM>> GetBookingList()
        {
            var matches = await _dbContext.Bookings.Include(e => e.RoomBookings).ToListAsync();
            return _mapper.Map<List<BookingVM>>(matches);
        }
        public async Task<Booking> GetBookingById(int bookingId)
        {
            var matches = await _dbContext.Bookings.Where(e=>e.BookingId==bookingId).ToListAsync();
            return matches.FirstOrDefault();
        }
        public async Task<List<BookingVM>> GetBookingListByUserId(string userId)
        {
            var matches = await _dbContext.Bookings.Include(e => e.RoomBookings).Where(e=>e.CreatedBy==userId).ToListAsync();
            return _mapper.Map<List<BookingVM>>(matches);
        }
        public async Task<List<BookingVM>> GetBookingListByByPropId(int propertyId)
        {
            var property = await _dbContext.Rooms.Where(e => e.PropertyID == propertyId).Select(x => x.RoomId).ToListAsync();
            var matches = await _dbContext.Bookings.Include(e=>e.RoomBookings).Where(e => e.RoomBookings.Any(c => property.Contains(c.RoomId))).ToListAsync();
            return _mapper.Map<List<BookingVM>>(matches);
        }


        public async Task<Booking> GetBookingListByIdAsync(int bookingId)
        {
            var matches = await _dbContext.Bookings.Include(e=>e.RoomBookings).Where(e=>e.BookingId== bookingId).FirstOrDefaultAsync();
            return _mapper.Map<Booking>(matches);
        }
        public async Task<decimal> GetRoomRent(int roomId)
        {
            var result = await _dbContext.Rooms.Where(e => e.RoomId == roomId).FirstOrDefaultAsync();
            return result.RegularPrice;
        }
        public async Task<List<BookingVM>> GetBookingListByDate(int roomId, DateTime fromDate, DateTime toDate)
        {
            var newBookingVM = new List<BookingVM>();
            var matches = await _dbContext.RoomBookingLinks.Where(e => e.RoomId == roomId).Select(x=>x.BookingId).ToListAsync();
            var bookingList = await _dbContext.Bookings.Where(e => e.RoomBookings.Any(c => matches.Contains(c.BookingId))).ToListAsync();
            TimeSpan inputSpan = toDate - fromDate;
            List<DateTime> range = new List<DateTime>();
            for (int day = 0; day < inputSpan.Days; day++)
            {
                range.Add(toDate.AddDays(day - inputSpan.Days));

                
            }
            var actualBookingList = new List<Booking>();
            foreach (var booking in bookingList)
            {
                for (int i = 0; i < range.Count; i++)
                {
                    if (range[i].Date >= booking.CheckIn.Date && range[i].Date <= booking.CheckOut.Date)
                    {
                        actualBookingList.Add(booking);
                    }
                }
            }
            var bookingIds = new List<int>();
            var bookedRoomCount = new List<int>();
            if (actualBookingList != null || actualBookingList.Count > 0)
            {
                actualBookingList = actualBookingList.Distinct().ToList();
            }
            for (int j = 0; j < actualBookingList.Count; j++)
            {
              
                bookedRoomCount.Add(await _dbContext.RoomBookingLinks.Where(e => e.BookingId == actualBookingList[j].BookingId).Select(x => x.NumberOfRooms).FirstOrDefaultAsync());
            }
            
            
            var count = 0;
           
            foreach (var booking in actualBookingList)
              {
               
                for (int i = 0; i < range.Count; i++)
                {
                    if (range[i].Date >= booking.CheckIn.Date && range[i].Date <= booking.CheckOut.Date)
                    {
                      
                        var roomCount = await _dbContext.RoomBookingLinks.Where(e => e.BookingId == booking.BookingId).Select(x => x.NumberOfRooms).FirstOrDefaultAsync();
                        var totalRooms = await _dbContext.Rooms.Where(e => e.RoomId == roomId).Select(e => e.NumberOfRoomsCategory).FirstOrDefaultAsync();
                        var tempBooking = new BookingVM();
                        tempBooking.BookedDate = range[i].Date;
                        tempBooking.BookingId = booking.BookingId;
                        tempBooking.isBlocked = booking.isBlocked;
                        tempBooking.ArrivalTime = booking.ArrivalTime;
                        tempBooking.ConfirmEmailId = booking.ConfirmEmailId;
                        tempBooking.EmailId = booking.EmailId;
                        tempBooking.CheckIn = booking.CheckIn;
                        tempBooking.CheckOut = booking.CheckOut;
                        tempBooking.FirstName = booking.FirstName;
                        tempBooking.LastName = booking.LastName;
                        tempBooking.PaymentStatus = booking.PaymentStatus;
                        tempBooking.PhoneNumber = booking.PhoneNumber;
                        tempBooking.RoomId = roomId;
                        tempBooking.SpecialRequest = booking.SpecialRequest;
                        tempBooking.TotalAmount = booking.TotalAmount;
                        tempBooking.RoomsLeft = Convert.ToInt32(totalRooms) - bookedRoomCount.Sum();
                        tempBooking.NoOfRoomsSelected = booking.isBlocked==true || booking.isBlocked==null ? roomCount : 0;
                        newBookingVM.Add(tempBooking);
                    }
                
                }
                count++;
            }

            for (int k = 0; k < range.Count; k++)
            {
                if (newBookingVM.Where(e => e.BookedDate.Date != range[k].Date).ToList().Count==newBookingVM.Count)
                {
                    var totalRooms = await _dbContext.Rooms.Where(e => e.RoomId == roomId).Select(e => e.NumberOfRoomsCategory).FirstOrDefaultAsync();
                    var tempBooking = new BookingVM();
                    tempBooking.BookedDate = range[k];
                    tempBooking.BookingId = 0;
                    tempBooking.isBlocked = false;
                    tempBooking.ArrivalTime = String.Empty;
                    tempBooking.ConfirmEmailId = String.Empty;
                    tempBooking.EmailId = String.Empty;
                    tempBooking.CheckIn = range[k];
                    tempBooking.CheckOut = range[k];
                    tempBooking.FirstName = String.Empty;
                    tempBooking.LastName = String.Empty;
                    tempBooking.PaymentStatus = false;
                    tempBooking.PhoneNumber = String.Empty;
                    tempBooking.RoomId = roomId;
                    tempBooking.SpecialRequest = String.Empty;
                    tempBooking.RoomsLeft =Convert.ToInt32(totalRooms);
                    tempBooking.NoOfRoomsSelected = 0;
                    newBookingVM.Add(tempBooking);
                }
                else
                {
                    continue;
                }
            }
                return _mapper.Map<List<BookingVM>>(newBookingVM);
        }           
      }
    }

