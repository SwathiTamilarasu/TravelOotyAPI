using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Bookings.Query.GetRoomBookingsByDate
{
    public class GetRoomBookingByDateHandler: IRequestHandler<GetRoomBookingByDate, List<BookingVM>>
    {
    
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetRoomBookingByDateHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public async Task<List<BookingVM>> Handle(GetRoomBookingByDate request, CancellationToken cancellationToken)
        {
            var allRooms = await _bookingRepository.GetBookingListByDate(request.RoomId,request.FromDate,request.ToDate);
            return _mapper.Map<List<BookingVM>>(allRooms);
        }
    }
}
