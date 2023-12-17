using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType;

namespace TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType
{
    public class UpdatePropertyTypeCommand: IRequest<UpdatePropertyTypeCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
