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

namespace TravelOoty.Application.Features.RoomsImageDetails.Command.DeleteRoomImage
{
    public class DeleteRoomImageHandler: IRequestHandler<DeleteRoomImageCommand>
    {
        private readonly IRoomImageRepository _roomRepository;
        private readonly IMapper _mapper;
        public DeleteRoomImageHandler(IMapper mapper, IRoomImageRepository roomImageRepository)
        {
            _mapper = mapper;
            _roomRepository = roomImageRepository;
        }

        public async Task<Unit> Handle(DeleteRoomImageCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _roomRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _roomRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
