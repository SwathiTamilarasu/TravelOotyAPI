using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Contracts.Persistance
{
    public interface IPropertyRepository : IAsyncRespository<Property>
    {
        Task<List<PropertyListVM>> GetPropertyList(StringValues Filter);
        Task<bool> IsPropertyNameUnique(string name);
        Task<UpdatePropertyCommand> GetPropertyById(int propertyId);
        Task<Property> GetPropEntityById(int propertyId);
        Task<List<PropertyListVM>> GetApprovedPropertyList(StringValues Filter);
        Task<Property> GetPropertyToUpdateById(int propertyId);
        Task<PropertyListVM> GetPropertyByUserId(string userId);
        Task<PropertyListVM> GetPropertyInfoById(int propertyId);
        Task<UpdatePropertyCommand> GetPropertyByIdForPatch(int propertyId);
        Task<Property> GetPropertyByRoomIdAsync(int roomId);
        Task<List<PropertyListVM>> GetPropertyInfoByName(string name);
    }
}
