using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory
{
    public class CreateHotelCategoryCommandHandler: IRequestHandler<CreateHotelCategoryCommand, CreateHotelCategoryCommandResponse>
    {
        private readonly IHotelCategoryRepository _hotelCategoryRepository;
        private readonly IMapper _mapper;
        public CreateHotelCategoryCommandHandler(IMapper mapper, IHotelCategoryRepository hotelCategoryRepository)
        {
            _mapper = mapper;
            _hotelCategoryRepository = hotelCategoryRepository;

        }

        public async Task<CreateHotelCategoryCommandResponse> Handle(CreateHotelCategoryCommand request, CancellationToken cancellationToken)
        {
            var createHotelCategoryCommandResponse = new CreateHotelCategoryCommandResponse();

            var validator = new CreateHotelCategoryCommandValidator(_hotelCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createHotelCategoryCommandResponse.Success = false;
                createHotelCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createHotelCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createHotelCategoryCommandResponse.Success)
            {
                var @amenities = _mapper.Map<TravelOoty.Domain.Entities.HotelCategory>(request);
                @amenities = await _hotelCategoryRepository.AddAsync(@amenities);
                createHotelCategoryCommandResponse.HotelCategoriesDto = _mapper.Map<HotelCategoriesDto>(@amenities);
            }
            return createHotelCategoryCommandResponse;
        }
    }
}
