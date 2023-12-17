using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory
{
    internal class CreateRoomCategoryCommandHandler: IRequestHandler<CreateRoomCategoryCommand, CreateRoomCategoryCommandResponse>
    {
        private readonly IRoomCategoryRepository _roomCategoryRepository;
        private readonly IMapper _mapper;
        public CreateRoomCategoryCommandHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository)
        {
            _mapper = mapper;
            _roomCategoryRepository = roomCategoryRepository;

        }

        public async Task<CreateRoomCategoryCommandResponse> Handle(CreateRoomCategoryCommand request, CancellationToken cancellationToken)
        {
            var createRoomCategoryCommandResponse = new CreateRoomCategoryCommandResponse();

            var validator = new CreateRoomCategoryCommandValidator(_roomCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createRoomCategoryCommandResponse.Success = false;
                createRoomCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRoomCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createRoomCategoryCommandResponse.Success)
            {
                var @roomCategory = _mapper.Map<TravelOoty.Domain.Entities.RoomCategory>(request);
                @roomCategory = await _roomCategoryRepository.AddAsync(@roomCategory);
                createRoomCategoryCommandResponse.RoomCategoriesDto = _mapper.Map<RoomCategoriesDto>(@roomCategory);
            }
            return createRoomCategoryCommandResponse;
        }
    }
}
