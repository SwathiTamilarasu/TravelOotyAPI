using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Hotels.Queries.GetHotelExport
{
    public  class GetHotelExportQuery: IRequest<HotelExportFileVm>
    {
    }
}
