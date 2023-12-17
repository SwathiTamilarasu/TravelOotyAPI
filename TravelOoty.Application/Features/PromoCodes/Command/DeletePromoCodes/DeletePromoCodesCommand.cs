using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PromoCodes.Command.DeletePromoCodes
{
    public class DeletePromoCodesCommand: IRequest
    {
        public int Id { get; set; }

    }
}
