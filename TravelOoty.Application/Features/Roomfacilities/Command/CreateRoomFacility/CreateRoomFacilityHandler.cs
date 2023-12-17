using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility
{
    public class CreateRoomFacilityHandler: IRequestHandler<CreateRoomFacilityCommand, CreateRoomFacilityResponse>
    {
        private readonly IRoomFacilityRepository _roomFacilityRepository;
        private readonly IMapper _mapper;
        public CreateRoomFacilityHandler(IMapper mapper, IRoomFacilityRepository roomFacilityRepository)
        {
            _mapper = mapper;
            _roomFacilityRepository = roomFacilityRepository;
        }

        public async Task<CreateRoomFacilityResponse> Handle(CreateRoomFacilityCommand request, CancellationToken cancellationToken)
        {
            var createRoomFacilityCommandResponse = new CreateRoomFacilityResponse();

            var validator = new CreateRoomFacilityValidator(_roomFacilityRepository);
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
                var @hotel = _mapper.Map<TravelOoty.Domain.Entities.RoomFacility>(request);
                @hotel = await _roomFacilityRepository.AddAsync(@hotel);
                createRoomFacilityCommandResponse.CreateRoomFacilityDto = _mapper.Map<CreateRoomFacilityDto>(@hotel);
            }
            return createRoomFacilityCommandResponse;
        }
    }
}
