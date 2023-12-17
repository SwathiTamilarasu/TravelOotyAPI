using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities
{
    public class UpdateAmenitiesCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
