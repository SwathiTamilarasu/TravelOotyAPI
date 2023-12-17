using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.Rooms.Query
{
    public class GetRoomQueryHandler: IRequestHandler<GetRoomQuery, RoomVM>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GetRoomQueryHandler(IMapper mapper, IRoomRepository roomRespository)
        {
            _mapper = mapper;
            _roomRepository = roomRespository;
        }
        public async Task<RoomVM> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var allRooms = (await _roomRepository.GetRoomsByRoomIdAsync(request.RoomId));
            return _mapper.Map<RoomVM>(allRooms);
        }

    }
}
