using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Features.Hotels.Queries.GetHotelExport;

namespace TravelOoty.Infrastructure.FileExport
{
    public class CsvExporter:ICsvExporter
    {
        public byte[] ExportHotelsToCsv(List<HotelExportDto> hotelExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(writer, new CultureInfo("en-US", false));
                csvWriter.WriteRecords(hotelExportDtos);
            }
            return memoryStream.ToArray();
        }
    }
}
