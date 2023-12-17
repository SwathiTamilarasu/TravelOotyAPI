using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Property.Command.UpdateProperty;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Application.Features.PropertyAmenitiesLink.Command;
using TravelOoty.Application.Features.RoomsImageDetails.Query;
using TravelOoty.Domain.Entities;
using TravelOoty.Persistance.Utility;

namespace TravelOoty.Persistance.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> _roomFacilitylRepository;
        private readonly IMapper _mapper;
        public PropertyRepository(TravelOotyDbContext dbContext, IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> roomFacilityRespository) : base(dbContext)
        {
            _mapper = mapper;
            _roomFacilitylRepository = roomFacilityRespository;
        }
        public Task<bool> IsPropertyNameUnique(string name)
        {
            var matches = _dbContext.Properties.Any(n => n.Name.Equals(name));
            return Task.FromResult(matches);
        }
        public async Task<List<PropertyListVM>> GetPropertyList(StringValues Filter)
        {
            var matches = _dbContext.Properties.Where(e => e.ApprovalStatus == PropertyEnum.ApprovalStatus.Registered.ToString()).Include(e=>e.PropertyType).Include(e=>e.AmenitiesJoins).Include(e=>e.Rooms).ToList();
            
            if (Filter.Count > 0)
            {
                 matches=  FilterProperty(Filter,matches);   
            }
            return await GetAllPropertyWithAmenities(matches.ToList());
        }
        public async Task<List<PropertyListVM>> GetApprovedPropertyList(StringValues Filter)
        {
            var matches = await _dbContext.Properties.Where(e=>e.ApprovalStatus== PropertyEnum.ApprovalStatus.Approved.ToString()).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            if (Filter.Count > 0)
            {
                matches = matches.Where(e => e.IsActive).ToList();
                matches = FilterProperty(Filter, matches);
            
            }
            
            return await GetAllPropertyWithAmenities(matches);

        }
        public async Task<UpdatePropertyCommand> GetPropertyById(int propertyId)
        {
            var matches = await _dbContext.Properties.Where(e=>e.PropertyID== propertyId).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            var result = await GetAllPropertyWithAmenities(matches);
            return _mapper.Map<UpdatePropertyCommand>(result.FirstOrDefault());
        }
        public async Task<UpdatePropertyCommand> GetPropertyByIdForPatch(int propertyId)
        {
            
                var matches = await _dbContext.Properties.Where(e => e.PropertyID == propertyId).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
                var result = await GetAllPropertyWithAmenitiesForUpdate(matches);
                return _mapper.Map<UpdatePropertyCommand>(result.FirstOrDefault());
            
        }

        public async Task<PropertyListVM> GetPropertyInfoById(int propertyId)
        {
            var matches = await _dbContext.Properties.Where(e => e.PropertyID == propertyId).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            var result = await GetAllPropertyWithAmenities(matches);
           
            return result.FirstOrDefault();
        }

        public async Task<List<PropertyListVM>> GetPropertyInfoByName(string name)
        {
            var matches = await _dbContext.Properties.Where(e => e.Name.StartsWith(name)).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            var result = await GetAllPropertyWithAmenities(matches);

            return result;
        }
        public async Task<Property> GetPropEntityById(int propertyId)
        {
            var matches = await _dbContext.Properties.Where(e => e.PropertyID == propertyId).Include(e=>e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            return matches.FirstOrDefault();
        }
        public async Task<Property> GetPropertyToUpdateById(int propertyId)
        {
            var matches = await _dbContext.Properties.Where(e => e.PropertyID == propertyId).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();            
            return matches.FirstOrDefault();
        }
        public async Task<Property> GetPropertyByRoomIdAsync(int roomId)
        {
            var matches = await _dbContext.Properties.Include(e => e.Rooms).Where(t => t.Rooms.Any(m => m.RoomId == roomId)).FirstOrDefaultAsync(); ;
            return matches;
        }
        public async Task<PropertyListVM> GetPropertyByUserId(string userId)
        {
            var matches = await _dbContext.Properties.Where(e => e.CreatedBy == userId).Include(e => e.Rooms).Include(e => e.PropertyType).Include(e => e.AmenitiesJoins).ToListAsync();
            if (matches != null)
            {
                var result= await GetAllPropertyWithAmenities(matches);
                return result.FirstOrDefault();
            }
            else
            {
                return new PropertyListVM();
            }
        }

        public async Task<List<PropertyListVM>> GetAllPropertyWithAmenities(List<Property> properties)
        {
          
            var propertyListVM = new List<PropertyListVM>();
            var roomListDto = new List<RoomListDto>();
            var amenitiesList = new List<Amenities>();           
            amenitiesList = await _dbContext.Amenities.ToListAsync();
            var roomfacilityNewList = new List<RoomFacilityLinkListDto>();
            var roomFacilityList = (await _roomFacilitylRepository.ListAllAsync()).OrderBy(x => x.Name);
            var roomCategory = await _dbContext.RoomsCategory.ToListAsync();
            foreach (var property in properties)
            {
                var amenitiesListJoin = new List<PropertyAmenitiesLinkDto>();
                roomListDto = _mapper.Map<List<RoomListDto>>(await _dbContext.Rooms.Include(e => e.FacilityJoins).Where(e => e.PropertyID == property.PropertyID).ToListAsync());
                if (property.AmenitiesJoins != null)
                {
                    foreach (var amenity in property.AmenitiesJoins)
                    {
                        var tempAmenity = property.AmenitiesJoins.Where(e => e.AmenitiesId == amenity.AmenitiesId).FirstOrDefault();
                        amenity.Amenities.Name = amenitiesList.Where(e => e.AmenitiesId == amenity.AmenitiesId).Select(e => e.Name).FirstOrDefault().ToString();
                        amenitiesListJoin.Add(new PropertyAmenitiesLinkDto
                        {
                            AmenitiesId = amenity.AmenitiesId,
                            Name = amenity.Amenities.Name,
                            PropertyID = amenity.PropertyID
                        });
                    }
                }
                
               
                List<RoomListDto> roomListDtoTemp = new List<RoomListDto>();
                foreach (var room in roomListDto)
                {
                    List<RoomImageVM> roomImageList = new List<RoomImageVM>();
                    var roomImageResult = await _dbContext.RoomImages.Where(e => e.RoomId ==room.RoomId).ToListAsync();
                    foreach (var roomImage in roomImageResult) {
                        //if (roomImage.RoomId == room.RoomId)
                        //{
                            roomImageList.Add(new RoomImageVM { Id = roomImage.Id, RoomId = roomImage.RoomId, ImageName = roomImage.ImageName, ImagePath = roomImage.ImagePath });
                       // }
                      }
                    for (int i = 0; i < room.FacilityJoins.Count; i++)
                    {
                        if (roomFacilityList.Where(e => e.RoomFacilityId == room.FacilityJoins[i].RoomFacilityId).FirstOrDefault().Name != null)
                        {
                            room.FacilityJoins[i].RoomFacilityName = roomFacilityList.Where(e => e.RoomFacilityId == room.FacilityJoins[i].RoomFacilityId).FirstOrDefault().Name.ToString();
                        }
                    }

                    room.RoomsImageDetails = roomImageList;
                    room.RoomCategoryName = roomCategory.Where(e => e.RoomCategoryId == room.RoomCategoryId).FirstOrDefault().Name.ToString();

                    roomListDtoTemp.Add(room);
                }
                if (property.AmenitiesJoins != null)
                {
                    property.AmenitiesJoins.Clear();
                }
                propertyListVM.Add(new PropertyListVM
                {
                    
                    PropertyID = property.PropertyID,                
                    Address = property.Address,
                    CreatedDate = property.CreatedDate,
                    CreatedBy = property.CreatedBy,
                    Email = property.Email,
                    ApprovalStatus = property.ApprovalStatus,
                    ImageName = property.ImageName,
                    ImagePath = property.ImagePath,
                    Name = property.Name,
                    PackageName = property.PackageName,
                    PhoneNumber = property.PhoneNumber,
                    PostalCode = property.PostalCode,
                    PropertierName = property.PropertierName,
                    Rooms = roomListDtoTemp,
                    PropertyType = _mapper.Map<PropPropertyTypeDto>(property.PropertyType),
                    AmenitiesJoins = amenitiesListJoin,
                    PropertyTypeId = property.PropertyTypeId,
                    TotalRooms = property.TotalRooms,
                    CheckInOut=property.CheckInOut,
                    AccountNumber = property.AccountNumber,
                    AccountName = property.AccountName,
                    FrontDeskTime = property.FrontDeskTime,
                    IfscCode   =property.IfscCode,
                    PropertyDesc=property.PropertyDesc,
                    CityId=property.CityId,
                    IsActive=property.IsActive,
                    Tax=property.Tax,
                    Lat=property.Lat,
                    Lng=property.Lng,
                });
            }
            return propertyListVM;
        }

        public async Task<List<UpdatePropertyCommand>> GetAllPropertyWithAmenitiesForUpdate(List<Property> properties)
        {

            var propertyListVM = new List<UpdatePropertyCommand>();
            var roomListDto = new List<UpdateRoomListDto>();
            var amenitiesList = new List<Amenities>();
            amenitiesList = await _dbContext.Amenities.ToListAsync();            
            var roomFacilityList = (await _roomFacilitylRepository.ListAllAsync()).OrderBy(x => x.Name);
            var roomCategory = await _dbContext.RoomsCategory.ToListAsync();
            foreach (var property in properties)
            {
                var amenitiesListJoin = new List<PropertyAmenitiesLinkDto>();
                roomListDto = _mapper.Map<List<UpdateRoomListDto>>(await _dbContext.Rooms.Where(e => e.PropertyID == property.PropertyID).ToListAsync());
                if (property.AmenitiesJoins != null)
                {
                    foreach (var amenity in property.AmenitiesJoins)
                    {
                        var tempAmenity = property.AmenitiesJoins.Where(e => e.AmenitiesId == amenity.AmenitiesId).FirstOrDefault();
                        amenity.Amenities.Name = amenitiesList.Where(e => e.AmenitiesId == amenity.AmenitiesId).Select(e => e.Name).FirstOrDefault().ToString();
                        amenitiesListJoin.Add(new PropertyAmenitiesLinkDto
                        {
                            AmenitiesId = amenity.AmenitiesId,
                            Name = amenity.Amenities.Name,
                            PropertyID = amenity.PropertyID
                        });
                    }
                }


                List<UpdateRoomListDto> roomListDtoTemp = new List<UpdateRoomListDto>();
                foreach (var room in roomListDto)
                {
                    List<RoomImageVM> roomImageList = new List<RoomImageVM>();
                    var roomImageResult = await _dbContext.RoomImages.Where(e => e.RoomId == room.RoomId).ToListAsync();
                    foreach (var roomImage in roomImageResult)
                    {
                        //if (roomImage.RoomId == room.RoomId)
                        //{
                        roomImageList.Add(new RoomImageVM { Id = roomImage.Id, RoomId = roomImage.RoomId, ImageName = roomImage.ImageName, ImagePath = roomImage.ImagePath });
                        // }
                    }
                

                    room.RoomsImageDetails = roomImageList;
                    room.RoomCategoryName = roomCategory.Where(e => e.RoomCategoryId == room.RoomCategoryId).FirstOrDefault().Name.ToString();

                    roomListDtoTemp.Add(room);
                }
                if (property.AmenitiesJoins != null)
                {
                    property.AmenitiesJoins.Clear();
                }
                propertyListVM.Add(new UpdatePropertyCommand
                {
                    PropertyID = property.PropertyID,
                    Address = property.Address,
                    CreatedDate = property.CreatedDate,
                    CreatedBy = property.CreatedBy,
                    Email = property.Email,
                    ApprovalStatus = property.ApprovalStatus,
                    ImageName = property.ImageName,
                    ImagePath = property.ImagePath,
                    Name = property.Name,
                    PackageName = property.PackageName,
                    PhoneNumber = property.PhoneNumber,
                    PostalCode = property.PostalCode,
                    PropertierName = property.PropertierName,
                    Rooms = roomListDtoTemp,
                    PropertyType = _mapper.Map<PropPropertyTypeDto>(property.PropertyType),
                    AmenitiesJoins = amenitiesListJoin,
                    PropertyTypeId = property.PropertyTypeId,
                    TotalRooms = property.TotalRooms,
                    CheckInOut = property.CheckInOut,
                    AccountNumber = property.AccountNumber,
                    AccountName = property.AccountName,
                    FrontDeskTime = property.FrontDeskTime,
                    IfscCode = property.IfscCode,
                    PropertyDesc = property.PropertyDesc,
                    CityId = property.CityId,
                });
            }
            return propertyListVM;
        }
        public List<Property> FilterProperty(StringValues Filter,List<Property> properties)
        {
            var propertyListVM = new List<Property>();
            try
            {
                int filterCount = 0;
                var filteredProperty = new List<int>();
                if (Filter.Count > 0)
                {
                    var filter = Filter.First();
                    var pieces = filter.Split("AND");
                    if (pieces.Length > 0)
                    {
                        for (int i = 0; i < pieces.Length; i++)
                        {
                            var propertyType = pieces[i].Split('=')[0];
                            switch (propertyType.ToLower())
                            {
                                case "cityid":
                                    {
                                        var cityIds = pieces[i].Split('=')[1].Split(',');
                                        if (cityIds[0] != "undefined")
                                        {
                                            var cityIdList = new List<int>();
                                            for (int j = 0; j < cityIds.Length; j++)
                                            {
                                                cityIdList.Add(int.Parse(cityIds[j]));
                                            }
                                            var propertyIds = properties.Where(e => cityIdList.Contains(e.CityId)).ToList().Select(e => e.PropertyID).ToArray();
                                            for (int k = 0; k < propertyIds.Length; k++)
                                            {
                                                filteredProperty.Add(propertyIds[k]);

                                            }
                                        }
                                        else
                                        {
                                            filterCount++;
                                            continue;
                                        }
                                    }
                                    break;
                                case "amenitiesjoins":
                                    {
                                        var cityIds = pieces[i].Split('=')[1].Split(',');
                                        if (cityIds[0] != "undefined")
                                        {
                                            var cityIdList = new List<int>();
                                            for (int j = 0; j < cityIds.Length; j++)
                                            {
                                                cityIdList.Add(int.Parse(cityIds[j]));

                                            }
                                            var propertyIds = properties.Where(e => e.AmenitiesJoins.Any(c => cityIdList.Contains(c.AmenitiesId))).ToList().Select(e => e.PropertyID).ToArray();
                                            for (int k = 0; k < propertyIds.Length; k++)
                                            {
                                                filteredProperty.Add(propertyIds[k]);

                                            }
                                        }
                                        else
                                        {
                                            filterCount++;
                                            continue;
                                        }
                                    }
                                    break;
                                case "price":
                                    {

                                        var cityIds = pieces[i].Split('=')[1].Split(',');
                                        if (cityIds[0] != "undefined")
                                        {
                                            var cityIdList = new List<int>();
                                            for (int j = 0; j < cityIds.Length; j++)
                                            {
                                                cityIdList.Add(int.Parse(cityIds[j]));

                                            }
                                            var resultProp = properties.Where(e => e.Rooms.Any(c => c.RegularPrice >= cityIdList[0] && c.RegularPrice <= cityIdList[1])).ToList();
                                            var propertyIds = resultProp.Select(e => e.PropertyID).ToArray();
                                            for (int k = 0; k < propertyIds.Length; k++)
                                            {
                                                filteredProperty.Add(propertyIds[k]);

                                            }
                                        }
                                        else
                                        {
                                            filterCount++;
                                            continue;
                                        }
                                    }
                                    break;
                                case "properttype":
                                    {
                                        var cityIds = pieces[i].Split('=')[1].Split(',');
                                        if (cityIds[0] != "undefined")
                                        {
                                            var cityIdList = new List<int>();
                                            for (int j = 0; j < cityIds.Length; j++)
                                            {
                                                cityIdList.Add(int.Parse(cityIds[j]));

                                            }
                                            var propertyIds = properties.Where(e => cityIdList.Contains(e.PropertyTypeId)).ToList().Select(e => e.PropertyID).ToArray();
                                            for (int k = 0; k < propertyIds.Length; k++)
                                            {
                                                filteredProperty.Add(propertyIds[k]);

                                            }
                                        }
                                        else
                                        {
                                            filterCount++;
                                            continue;
                                        }
                                    }
                                    break;
                                case "name":
                                    {
                                        var propName = pieces[i].Split('=')[1];
                                        if (propName != "undefined")
                                        {
                                            var propertyIds = properties.Where(e => e.Name.ToLower().Contains(propName.ToLower())).ToList().Select(e => e.PropertyID).ToArray();


                                            for (int k = 0; k < propertyIds.Length; k++)
                                            {
                                                filteredProperty.Add(propertyIds[k]);

                                            }
                                        }
                                        else
                                        {
                                            filterCount++;
                                            continue;
                                        }

                                    }
                                    break;
                                case "checkinout":
                                    {
                                        var roomCheckin = pieces[i].Split('=')[1].Split(',');
                                        if (roomCheckin[0] != "undefined")
                                        {
                                            //var roomCheckInOutList = new List<DateTime>();
                                            //for(int d=0;d<roomCheckin.Length;d++)
                                            //{
                                            //    roomCheckInOutList.Add(Convert.ToDateTime(roomCheckin[d]));
                                            //}
                                            //var bookedRooms=_dbContext.Bookings.Where(e => e.CheckIn.Date >= roomCheckInOutList[0].Date && e.CheckOut.Date <= roomCheckInOutList[1].Date).Select(e => e.RoomId).ToList();
                                            //var propertyIds = properties.Where(e => e.Rooms.Any(c => !bookedRooms.Contains(c.RoomId))).Select(d => d.PropertyID).ToArray();
                                            
                                            //for (int k = 0; k < propertyIds.Length; k++)
                                            //{
                                            //    filteredProperty.Add(propertyIds[k]);

                                            //}


                                        }
                                    }
                                    break;
                            }
                        }
                        var result = filteredProperty.GroupBy(x => x).Where(c => c.Count() > 1).Select(x => x.Key).ToList();
                        if (result.Count == 0)
                        {
                           
                            //if (filterCount == 3)
                            //{
                            //    propertyListVM = properties.ToList();
                               
                            //}                          
                            //else
                            //{
                                propertyListVM = properties.Where(e => filteredProperty.Distinct().Contains(e.PropertyID)).ToList();
                            //}
                        }
                        else
                        {
                           
                            propertyListVM = properties.Where(e => result.Distinct().Contains(e.PropertyID)).ToList();
                        }

                        
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return propertyListVM;
        }
    }
}