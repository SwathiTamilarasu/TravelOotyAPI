using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Rooms.Command.CreateRoom
{
    public class CreateRoomHandler: IRequestHandler<CreateRoomCommand, CreateRoomResponse>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public CreateRoomHandler(IMapper mapper, IRoomRepository roomRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<CreateRoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var createRoomResponse = new CreateRoomResponse();
            var propertyInfo = await _propertyRepository.GetPropertyByUserId(request.CreatedBy);
          
            if(propertyInfo != null)
            {
                request.PropertyID = propertyInfo.PropertyID;
            }
            else
            {
                return createRoomResponse;
            }

            var validator = new CreateRoomValidator(_roomRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createRoomResponse.Success = false;
                createRoomResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRoomResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createRoomResponse.Success)
            {
                var @property = _mapper.Map<TravelOoty.Domain.Entities.Rooms>(request);
                @property = await _roomRepository.AddAsync(@property);
                createRoomResponse.PropertyDto = _mapper.Map<RoomDto>(@property);
            }
            return createRoomResponse;
        }
    }
}
