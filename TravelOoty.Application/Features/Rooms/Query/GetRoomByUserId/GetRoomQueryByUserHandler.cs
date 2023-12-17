using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Rooms.Query.GetRoomByUserId
{
    public class GetRoomQueryByUserHandler: IRequestHandler<GetRoomQueryByUser, List<RoomVM>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetRoomQueryByUserHandler(IMapper mapper, IRoomRepository roomRespository)
        {
            _mapper = mapper;
            _roomRepository = roomRespository;
        }
        public async Task<List<RoomVM>> Handle(GetRoomQueryByUser request, CancellationToken cancellationToken)
        {
            var allRooms = (await _roomRepository.GetRoomsByUserAsync(request.UserId));
            return _mapper.Map<List<RoomVM>>(allRooms);
        }
    }
}
