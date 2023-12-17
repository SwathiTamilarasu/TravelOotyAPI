using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Exceptions;

namespace TravelOoty.Application.Features.Rooms.Command.UpdateRoom
{
    public class UpdateRoomHandler: IRequestHandler<UpdateRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public UpdateRoomHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;

        }
        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _roomRepository.GetRoomsByRoomIdAsync(request.RoomId.ToString());

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Rooms), request.RoomId);
            }

       

            _mapper.Map(request, eventToUpdate, typeof(UpdateRoomCommand), typeof(TravelOoty.Domain.Entities.Rooms));

            await _roomRepository.UpdateAsync(_mapper.Map<TravelOoty.Domain.Entities.Rooms>(eventToUpdate));

            return Unit.Value;
        }

    }
}
