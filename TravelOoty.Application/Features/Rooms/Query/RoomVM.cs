using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.RoomFacilityLink.Query;

namespace TravelOoty.Application.Features.Rooms.Query
{
    public class RoomVM
    {
        public int RoomId { get; set; }        
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SpecialPrice { get; set; }            
        public int RoomCategoryId { get; set; }
        public string RoomCategoryName { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }
        public List<RoomFacilityLinkDto> FacilityJoins { get; set; }
        public string NumberOfRoomsCategory { get; set; }
        public string CancellationPolicy { get; set; }
    }
}
