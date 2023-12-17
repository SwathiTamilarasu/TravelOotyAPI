using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyAmenitiesLink.Command;
using TravelOoty.Application.Features.Rooms.Command.CreateRoom;

namespace TravelOoty.Application.Features.Property.Command.CreateProperty
{
    public class PropertyDto
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public string PropertierName { get; set; }      
        public int PropertyTypeId { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }        
        public string PackageName { get; set; }
        public string ImageName { get; set; }
        public Uri ImagePath { get; set; }
        public string PostalCode { get; set; }
        //Rooms 
        public int TotalRooms { get; set; }       
        public  IList<RoomDto> Rooms { get; set; }
        public List<PropertyAmenitiesLinkDto> propertyAmenitiesLinks { get; set; }
        public string ApprovalStatus { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CheckInOut { get; set; }
        public string FrontDeskTime { get; set; }
        public string PropertyDesc { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string IfscCode { get; set; }
        public float Tax { get; set; } = 0;
        public bool IsActive { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

    }
}
