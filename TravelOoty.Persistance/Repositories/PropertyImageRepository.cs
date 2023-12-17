using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.PropertyImageDetails.Command;
using TravelOoty.Application.Features.PropertyImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Persistance.Repositories
{
    public class PropertyImageRepository: BaseRepository<PropertyImageDetails>, IPropertyImageRepository
    {
        private readonly IMapper _mapper;
        public PropertyImageRepository(TravelOotyDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
        public Task<bool> IsPropertyImageNameUnique(string name)
        {
            var matches = _dbContext.RoomImages.Any(n => n.ImageName.Equals(name));
            return Task.FromResult(matches);
        }

        public async Task<Property> GetPropertyByPropertyIdAsync(string propertyId)
        {
            var property = await _dbContext.Properties.Where(e => e.PropertyID == Convert.ToInt32(propertyId)).FirstOrDefaultAsync();
            return property;

        }
        public async Task<List<PropertyImageVM>> GetPropertyImageByIdAsyc(int propertyId)
        {
            var rooms = await _dbContext.PropertiesImages.Where(e => e.PropertyId == propertyId).ToListAsync();
            return _mapper.Map<List<PropertyImageVM>>(rooms);
        }
        public async Task<PropertyImageDetails> GetPropertyForUpdateImageByIdAsyc(int propertyId)
        {
            var rooms = await _dbContext.PropertiesImages.Where(e => e.PropertyId == propertyId).ToListAsync();
            return rooms.FirstOrDefault();
        }
    }
}
