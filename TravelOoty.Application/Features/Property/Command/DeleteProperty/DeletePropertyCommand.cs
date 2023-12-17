using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Property.Command.DeleteProperty
{
    public class DeletePropertyCommand: IRequest
    {
        public int Id { get; set; }

    }
}
