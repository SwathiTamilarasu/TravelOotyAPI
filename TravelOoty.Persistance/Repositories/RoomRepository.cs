using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Application.Features.RoomFacilityLink.Query;
using TravelOoty.Application.Features.Rooms.Query;
using TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByBooking;
using TravelOoty.Application.Features.RoomsImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class RoomRepository: BaseRepository<Rooms>, IRoomRepository
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> _roomFacilitylRepository;
        public RoomRepository(TravelOotyDbContext dbContext, IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> roomFacilityRespository) : base(dbContext)
        {
            _mapper = mapper;
            _roomFacilitylRepository = roomFacilityRespository;
        }
        public Task<bool> IsRoomNameUnique(string name)
        {
            var matches = _dbContext.Rooms.Any(n => n.Name.Equals(name));
            return Task.FromResult(matches);
        }

        //public Task<bool> IsRoomImageNameUnique(string imageName)
        //{
        //    var matches = _dbContext.Rooms.Any(n => n.ImageName.Equals(imageName));
        //    return Task.FromResult(matches);
        //}
        public async Task<List<RoomVM>> GetAllRooms()
        {
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Include(x => x.RoomCategory).ToListAsync();
            return _mapper.Map<List<RoomVM>>(rooms);
        }
        public async Task<List<RoomVM>> GetRoomsByPropertyAsync(string propertyID)
        {
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Where(e => e.PropertyID == Convert.ToInt32(propertyID)).ToListAsync();
            return _mapper.Map<List<RoomVM>>(rooms);
            
        }
        public async Task<List<RoomBookingVM>> GetRoomsByPropertyDateAsync(string propertyID, DateTime fromDate, DateTime toDate)
        {
            var roomsList = await _dbContext.Rooms.Include(f => f.FacilityJoins).Include(x => x.RoomCategory).Where(e => e.PropertyID == Convert.ToInt32(propertyID)).ToListAsync();
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Where(e => e.PropertyID == Convert.ToInt32(propertyID)).Select(x => x.RoomId).ToListAsync();
            var bookingList = await _dbContext.Bookings.Where(e => e.RoomBookings.Any(c => rooms.Contains(c.RoomId))).ToListAsync();
            var roomCategory = await _dbContext.RoomsCategory.ToListAsync();
            var roomFacilityList = (await _roomFacilitylRepository.ListAllAsync()).OrderBy(x => x.Name);
            var roomBooking = new List<RoomBookingVM>();
            TimeSpan inputSpan = toDate - fromDate;
            List<DateTime> range = new List<DateTime>();
            for (int day = 0; day <= inputSpan.Days; day++)
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
           
            foreach(var roomResult in roomsList)
            {
                if (!String.IsNullOrEmpty(roomResult.NumberOfRoomsCategory))
                {
                    var bookedRoomCount = new List<int>();
                    for (int j = 0; j < actualBookingList.Count; j++)
                    {

                        bookedRoomCount.Add(await _dbContext.RoomBookingLinks.Where(e => e.BookingId == actualBookingList[j].BookingId && e.RoomId == roomResult.RoomId).Select(x => x.NumberOfRooms).FirstOrDefaultAsync());
                    }
                    if (Convert.ToInt32(roomResult.NumberOfRoomsCategory) - bookedRoomCount.Sum() >= 1)
                    {
                        var tempRoom = new RoomBookingVM();
                        List<RoomImageVM> roomImageList = new List<RoomImageVM>();
                        var roomImageResult = await _dbContext.RoomImages.Where(e => e.RoomId == roomResult.RoomId).ToListAsync();
                        tempRoom.PropertyID = roomResult.PropertyID;
                        tempRoom.NumberOfRoomsCategory = roomResult.NumberOfRoomsCategory;
                        tempRoom.RoomId = roomResult.RoomId;
                        tempRoom.RoomCategoryId = roomResult.RoomCategoryId;
                        tempRoom.Name = roomResult.Name;
                        tempRoom.RegularPrice = roomResult.RegularPrice;
                        tempRoom.SpecialPrice = roomResult.SpecialPrice;
                        tempRoom.RoomCategoryName = roomCategory.Where(e => e.RoomCategoryId == roomResult.RoomCategoryId).FirstOrDefault().Name.ToString();
                        tempRoom.Guests = roomResult.Guests;
                        tempRoom.Beds = roomResult.Beds;
                        tempRoom.NumberOfRoomsCategory = roomResult.NumberOfRoomsCategory;
                        tempRoom.CancellationPolicy = roomResult.CancellationPolicy;
                        tempRoom.FacilityJoins = _mapper.Map<List<RoomFacilityLinkListDto>>(roomResult.FacilityJoins);
                        for (int i = 0; i < roomResult.FacilityJoins.Count; i++)
                        {
                            if (roomFacilityList.Where(e => e.RoomFacilityId == roomResult.FacilityJoins[i].RoomFacilityId).FirstOrDefault().Name != null)
                            {
                                if (roomFacilityList.Where(e => e.RoomFacilityId == roomResult.FacilityJoins[i].RoomFacilityId) != null)
                                {
                                    tempRoom.FacilityJoins[i].RoomFacilityName = roomFacilityList.Where(e => e.RoomFacilityId == roomResult.FacilityJoins[i].RoomFacilityId).FirstOrDefault().Name.ToString();
                                }
                            }
                        }
                        tempRoom.RoomCategories = _mapper.Map<RoomCategoryDto>(roomResult.RoomCategory);
                        tempRoom.RoomsImageDetails = _mapper.Map<List<RoomImageVM>>(roomImageResult);
                        tempRoom.RoomsLeft = Convert.ToInt32(roomResult.NumberOfRoomsCategory) - bookedRoomCount.Sum();
                        roomBooking.Add(tempRoom);
                    }
                }
            }
            if (roomBooking.Count > 0)
            {
                return roomBooking.Distinct().ToList();
            }
            else
            {
                return roomBooking;
            }

        }


        public async Task<Rooms> GetRoomsByRoomIdAsync(string roomId)
        {
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Include(x=>x.RoomCategory).Where(e => e.RoomId == Convert.ToInt32(roomId)).FirstOrDefaultAsync();
            return rooms;

        }
        public async Task<List<RoomVM>> GetRoomsByUserAsync(string userId)
        {
            var property =  _dbContext.Properties.Where(e => e.ApprovalStatus=="Approved" && e.CreatedBy==userId).AsEnumerable();
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Include(x => x.RoomCategory).Where(e => e.CreatedBy == userId).Join(property, a => a.PropertyID, b => b.PropertyID, (a, b) =>a).ToListAsync();
            return _mapper.Map<List<RoomVM>>(rooms);
        }


    }
}
