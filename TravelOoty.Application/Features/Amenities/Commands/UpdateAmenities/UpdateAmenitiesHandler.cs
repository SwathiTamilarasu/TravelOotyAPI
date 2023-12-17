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
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities
{
    public class UpdateAmenitiesHandler : IRequestHandler<UpdateAmenitiesCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Amenities> _amenitiesRepository;
        private readonly IMapper _mapper;

        public UpdateAmenitiesHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Amenities> amenitiesRepository)
        {
            _mapper = mapper;
            _amenitiesRepository = amenitiesRepository;
        }

        public async Task<Unit> Handle(UpdateAmenitiesCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _amenitiesRepository.GetByIdAsync(request.Id);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Amenities), request.Id);
            }

            var validator = new UpdateAmenitiesValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateAmenitiesCommand), typeof(TravelOoty.Domain.Entities.Amenities));

            await _amenitiesRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
