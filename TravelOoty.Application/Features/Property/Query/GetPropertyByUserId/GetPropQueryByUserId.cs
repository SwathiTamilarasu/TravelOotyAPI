using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetPropertyByUserId
{
    public class GetPropQueryByUserId: IRequest<PropertyListVM>
    {
        public string UserId { get; set; }
        public GetPropQueryByUserId(string userId)
        {
            UserId = userId;
        }
    }
}
