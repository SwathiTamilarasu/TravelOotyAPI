using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class RoomFacilityRepository: BaseRepository<RoomFacility>, IRoomFacilityRepository
    {
        public RoomFacilityRepository(TravelOotyDbContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsRoomFacilityNameUnique(string name)
        {
            var matches = _dbContext.PropertyTypes.Any(n => n.Name.Equals(name));
            return Task.FromResult(matches);
        }

    }
}
