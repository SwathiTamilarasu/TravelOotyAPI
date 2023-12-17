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

namespace TravelOoty.Application.Features.RoomCategory.Command.DeleteRoomCategory
{
    public class DeleteRoomCategoryHandler : IRequestHandler<DeleteRoomCategoryCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> _asyncRepository;
        private readonly IMapper _mapper;

        public DeleteRoomCategoryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCategoryCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _asyncRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _asyncRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
