using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyImageDetails.Command.DeletePropertyImage
{
    public class DeletePropImageCommand: IRequest
    {
        public int Id { get; set; }
    }
}
