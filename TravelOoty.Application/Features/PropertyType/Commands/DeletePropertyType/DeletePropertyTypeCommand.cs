using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyType.Commands.DeletePropertyType
{
    public class DeletePropertyTypeCommand: IRequest
    {
        public int Id { get; set; }
      
    }
}
