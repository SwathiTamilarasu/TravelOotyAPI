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

namespace TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility
{
    public class UpdateRoomFacilityHandler : IRequestHandler<UpdateRoomFacilityCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> _amenitiesRepository;
        private readonly IMapper _mapper;

        public UpdateRoomFacilityHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> amenitiesRepository)
        {
            _mapper = mapper;
            _amenitiesRepository = amenitiesRepository;
        }

        public async Task<Unit> Handle(UpdateRoomFacilityCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _amenitiesRepository.GetByIdAsync(request.RoomFacilityId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Amenities), request.RoomFacilityId);
            }

            var validator = new UpdateRoomFacilityValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateRoomFacilityCommand), typeof(TravelOoty.Domain.Entities.RoomFacility));

            await _amenitiesRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
