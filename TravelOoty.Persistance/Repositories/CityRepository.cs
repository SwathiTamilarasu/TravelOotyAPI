using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class CityRepository: BaseRepository<City>, ICityRepository
    {
        public CityRepository(TravelOotyDbContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsCityNameUnique(string name)
        {
            var matches = _dbContext.Cities.Any(n => n.Name.Equals(name));
            return Task.FromResult(matches);
        }
    }
}
