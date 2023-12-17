using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class Property : AuditableEntity
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public string PropertierName { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<PropertyAmenitiesLink> AmenitiesJoins { get; set; }
        public string PackageName { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string PostalCode { get; set; }
        public int TotalRooms { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
        public string ApprovalStatus { get; set; }
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
