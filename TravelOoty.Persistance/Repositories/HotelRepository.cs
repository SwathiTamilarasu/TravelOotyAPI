
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class HotelRepository: BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(TravelOotyDbContext dbContext):base(dbContext)
        {

        }
        public Task<bool> IsHotelNameUnique(string name)
        {
            var matches=_dbContext.Hotels.Any(n=>n.Name.Equals(name));
            return Task.FromResult(matches);
        }
    }
}
