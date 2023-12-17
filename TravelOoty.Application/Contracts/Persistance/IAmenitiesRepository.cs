using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IAmenitiesRepository: IAsyncRespository<Amenities>
    {
        Task<bool> IsPropertyTypeNameUnique(string name);
    }
}
