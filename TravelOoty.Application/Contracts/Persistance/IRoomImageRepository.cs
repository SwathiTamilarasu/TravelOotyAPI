using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.RoomsImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IRoomImageRepository: IAsyncRespository<RoomImageDetails>
    {
        Task<bool> IsRoomImageNameUnique(string name);
        Task<Rooms> GetRoomsByRoomIdAsync(string roomId);
        Task<List<RoomImageVM>> GetRoomImageByIdAsyc(int roomId);

    }
}
