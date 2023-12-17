using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByPropertyId
{
    public class GetRoomQueryByPropertyHandler  : IRequestHandler<GetRoomQueryByProperty, List<RoomVM>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetRoomQueryByPropertyHandler(IMapper mapper, IRoomRepository roomRespository)
        {
            _mapper = mapper;
            _roomRepository = roomRespository;
        }
        public async Task<List<RoomVM>> Handle(GetRoomQueryByProperty request, CancellationToken cancellationToken)
        {
            var allRooms = await _roomRepository.GetRoomsByPropertyAsync(request.PropertyId);
            return _mapper.Map<List<RoomVM>>(allRooms);
        }
    }
}
