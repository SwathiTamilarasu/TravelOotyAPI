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

namespace TravelOoty.Application.Features.Roomfacilities.Command.DeleteRoomFacility
{
    public class DeleteRoomFacilityHandler : IRequestHandler<DeleteRoomFacilityCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> _asyncRepository;
        private readonly IMapper _mapper;

        public DeleteRoomFacilityHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeleteRoomFacilityCommand request, CancellationToken cancellationToken)
        {
            var roomFacilityToDelete = await _asyncRepository.GetByIdAsync(request.RoomFacilityId);

            if (roomFacilityToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.RoomFacility), request.RoomFacilityId);
            }

            await _asyncRepository.DeleteAsync(roomFacilityToDelete);

            return Unit.Value;
        }
    }

}

