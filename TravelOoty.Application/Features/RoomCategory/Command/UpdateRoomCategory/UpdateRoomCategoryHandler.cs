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

namespace TravelOoty.Application.Features.RoomCategory.Command.UpdateRoomCategory
{
    public class UpdateRoomCategoryHandler: IRequestHandler<UpdateRoomCategoryCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> _roomCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateRoomCategoryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> roomCategoryRepository)
        {
            _mapper = mapper;
            _roomCategoryRepository = roomCategoryRepository;
        }

        public async Task<Unit> Handle(UpdateRoomCategoryCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _roomCategoryRepository.GetByIdAsync(request.Id);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.HotelCategory), request.Id);
            }

            var validator = new UpdateRoomCategoryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateRoomCategoryCommand), typeof(TravelOoty.Domain.Entities.HotelCategory));

            await _roomCategoryRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
