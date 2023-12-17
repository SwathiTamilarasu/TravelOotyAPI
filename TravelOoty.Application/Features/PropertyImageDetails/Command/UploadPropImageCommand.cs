using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyImageDetails.Query;

namespace TravelOoty.Application.Features.PropertyImageDetails.Command
{
    public class UploadPropImageCommand : IRequest<PropertyImageVM>
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
    }
}
