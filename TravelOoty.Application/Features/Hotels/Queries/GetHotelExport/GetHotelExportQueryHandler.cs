using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.Hotels.Queries.GetHotelExport
{
    public class GetHotelExportQueryHandler: IRequestHandler<GetHotelExportQuery,HotelExportFileVm>
    {
        private readonly IAsyncRespository<Hotel> _hotelRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csVExporter;

        public GetHotelExportQueryHandler(IMapper mapper, IAsyncRespository<Hotel> hotelRespository, ICsvExporter csVExporter)
        {
            _mapper = mapper;
            _hotelRepository = hotelRespository;
            _csVExporter = csVExporter;
        }

        public async Task<HotelExportFileVm> Handle(GetHotelExportQuery request, CancellationToken cancellationToken)
            {
            var allHotel = _mapper.Map<List<HotelExportDto>>((await _hotelRepository.ListAllAsync()).OrderBy(x => x.Name));
            var fileData = _csVExporter.ExportHotelsToCsv(allHotel);
            var hotelExportFileDto = new HotelExportFileVm() { ContentType = "text/csv", Data = fileData, FileName = $"{Guid.NewGuid()}.csv" };
            return hotelExportFileDto;
        }

    }
}
