using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyImageDetails.Query;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IPropertyImageRepository: IAsyncRespository<PropertyImageDetails>
    {
        Task<bool> IsPropertyImageNameUnique(string name);        
        Task<Property> GetPropertyByPropertyIdAsync(string propertyId);
        Task<List<PropertyImageVM>> GetPropertyImageByIdAsyc(int proprtyId);
        Task<PropertyImageDetails> GetPropertyForUpdateImageByIdAsyc(int propertyId);

    }
}
