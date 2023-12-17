using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Rooms.Query;
using TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByBooking;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IRoomRepository: IAsyncRespository<Rooms>
    {
         Task<List<RoomVM>> GetAllRooms();
        Task<bool> IsRoomNameUnique(string name);

        Task<List<RoomVM>> GetRoomsByPropertyAsync(string propertyID);
        Task<List<RoomBookingVM>> GetRoomsByPropertyDateAsync(string propertyID,DateTime fromDate, DateTime toDate);

        //Task<bool> IsRoomImageNameUnique(string imageName);

        Task<Rooms> GetRoomsByRoomIdAsync(string roomId);


        Task<List<RoomVM>> GetRoomsByUserAsync(string userId);
     


    }
}
