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

namespace TravelOoty.Application.Features.Rooms.Command.DeleteRoom
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public DeleteRoomHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _roomRepository.GetByIdAsync(request.RoomId);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.RoomId);
            }

            await _roomRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
