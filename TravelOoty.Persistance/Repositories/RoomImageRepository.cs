using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.RoomsImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class RoomImageRepository: BaseRepository<RoomImageDetails>, IRoomImageRepository
    {
        private readonly IMapper _mapper;
        public RoomImageRepository(TravelOotyDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public Task<bool> IsRoomImageNameUnique(string name)
        {
            var matches = _dbContext.RoomImages.Any(n => n.ImageName.Equals(name));
            return Task.FromResult(matches);
        }
        public async Task<Rooms> GetRoomsByRoomIdAsync(string roomId)
        {
            var rooms = await _dbContext.Rooms.Include(f => f.FacilityJoins).Where(e => e.RoomId == Convert.ToInt32(roomId)).FirstOrDefaultAsync();
            return rooms;

        }

        public async Task<List<RoomImageVM>> GetRoomImageByIdAsyc(int roomId)
        {
            var rooms = await _dbContext.RoomImages.Where(e => e.RoomId == roomId).ToListAsync();
            return _mapper.Map<List<RoomImageVM>>(rooms);
        }


    }
}
