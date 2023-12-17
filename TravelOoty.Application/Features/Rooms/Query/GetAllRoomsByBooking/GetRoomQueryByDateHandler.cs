using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByBooking
{
    public class GetRoomQueryByDateHandler: IRequestHandler<GetRoomQueryByDate, List<RoomBookingVM>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetRoomQueryByDateHandler(IMapper mapper, IRoomRepository roomRespository)
        {
            _mapper = mapper;
            _roomRepository = roomRespository;
        }
        public async Task<List<RoomBookingVM>> Handle(GetRoomQueryByDate request, CancellationToken cancellationToken)
        {
            var allRooms = await _roomRepository.GetRoomsByPropertyDateAsync(request.PropertyId,request.FromDate,request.ToDate);
            return allRooms;
        }
    }
}
