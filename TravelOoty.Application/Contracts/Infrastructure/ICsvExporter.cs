using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Hotels.Queries.GetHotelExport;

namespace TravelOoty.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportHotelsToCsv(List<HotelExportDto> hotelExportDtos);
    }
}
