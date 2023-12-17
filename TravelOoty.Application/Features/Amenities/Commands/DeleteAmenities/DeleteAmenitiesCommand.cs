using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Amenities.Commands.DeleteAmenities
{
    public class DeleteAmenitiesCommand:IRequest
    {
        public int Id { get; set; }
    }
}
