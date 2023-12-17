using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType
{
    public class CreatePropertyTypeCommand: IRequest<CreatePropertyTypeCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
