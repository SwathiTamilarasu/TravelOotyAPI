using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType;

namespace TravelOoty.Application.Features.Amenities.Commands.CreateAmenities
{
    public class CreateAmenitiesCommandHandler: IRequestHandler<CreateAmenitiesCommand, CreateAmenitiesCommandResponse>
    {
        private readonly IAmenitiesRepository _amenitiesRepository;
        private readonly IMapper _mapper;
        public CreateAmenitiesCommandHandler(IMapper mapper, IAmenitiesRepository amenitiesRepository)
        {
            _mapper = mapper;
            _amenitiesRepository = amenitiesRepository;

        }

        public async Task<CreateAmenitiesCommandResponse> Handle(CreateAmenitiesCommand request, CancellationToken cancellationToken)
        {
            var createAmenitiesCommandResponse = new CreateAmenitiesCommandResponse();

            var validator = new CreateAmenitiesCommandValidator(_amenitiesRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createAmenitiesCommandResponse.Success = false;
                createAmenitiesCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAmenitiesCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createAmenitiesCommandResponse.Success)
            {
                var @amenities = _mapper.Map<TravelOoty.Domain.Entities.Amenities>(request);
                @amenities = await _amenitiesRepository.AddAsync(@amenities);
                createAmenitiesCommandResponse.AmenitiesDto = _mapper.Map<AmenitiesDto>(@amenities);
            }
            return createAmenitiesCommandResponse;
        }

    }
}
