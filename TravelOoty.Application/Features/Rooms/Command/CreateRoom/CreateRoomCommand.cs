using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Application.Features.RoomFacilityLink.Query;

namespace TravelOoty.Application.Features.Rooms.Command.CreateRoom
{
    public class CreateRoomCommand: IRequest<CreateRoomResponse>
    {
        public int RoomId { get; set; }      
        public string Name { get; set; }
        public int PropertyID { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public int RoomCategoryId { get; set; }
        public int Guests { get; set; } = 2;
        public int Beds { get; set; } = 1;     
        public string CreatedBy { get; set; }
        public List<RoomFacilityLinkDto> FacilityJoins { get; set; }
        public string NumberOfRoomsCategory { get; set; }
        public string CancellationPolicy { get; set; }

    }
}
