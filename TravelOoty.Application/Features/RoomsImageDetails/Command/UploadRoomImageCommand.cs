using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.RoomsImageDetails.Query;

namespace TravelOoty.Application.Features.RoomsImageDetails.Command
{
    public class UploadRoomImageCommand : IRequest<RoomImageVM>
    {
     
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }     
        public IFormFile File { get; set; }
    }
}
