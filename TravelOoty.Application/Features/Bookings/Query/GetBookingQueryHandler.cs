using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Bookings.Query
{
    public class GetBookingQueryHandler: IRequestHandler<GetBookingQuery, List<BookingVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Booking> _asyncRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Booking> asyncRepository, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _bookingRepository = bookingRepository;
        }
        public async Task<List<BookingVM>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            //var allHotelCategory = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Name);
            //return _mapper.Map<List<PropertyListVM>>(allHotelCategory);

            var allBooking = await _bookingRepository.GetBookingList();
            return allBooking;
        }
    }
}
