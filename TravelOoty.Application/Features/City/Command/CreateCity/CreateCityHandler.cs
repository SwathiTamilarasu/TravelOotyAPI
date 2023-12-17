using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.City.Command.CreateCity
{
    public class CreateCityHandler: IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CreateCityHandler(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<CreateCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var createRoomFacilityCommandResponse = new CreateCityResponse();

            var validator = new CreateCityValidator(_cityRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createRoomFacilityCommandResponse.Success = false;
                createRoomFacilityCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRoomFacilityCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createRoomFacilityCommandResponse.Success)
            {
                var @city = _mapper.Map<TravelOoty.Domain.Entities.City>(request);
                @city = await _cityRepository.AddAsync(@city);
                createRoomFacilityCommandResponse.CreateCityDto = _mapper.Map<CreateCityDto>(@city);
            }
            return createRoomFacilityCommandResponse;
        }
    }
}
