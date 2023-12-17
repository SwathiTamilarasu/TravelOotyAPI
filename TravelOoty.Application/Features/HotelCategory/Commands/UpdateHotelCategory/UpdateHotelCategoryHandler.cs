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

namespace TravelOoty.Application.Features.HotelCategory.Commands.UpdateHotelCategory
{
    public class UpdateHotelCategoryHandler: IRequestHandler<UpdateHotelCategoryCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> _amenitiesRepository;
        private readonly IMapper _mapper;

        public UpdateHotelCategoryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> amenitiesRepository)
        {
            _mapper = mapper;
            _amenitiesRepository = amenitiesRepository;
        }

        public async Task<Unit> Handle(UpdateHotelCategoryCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _amenitiesRepository.GetByIdAsync(request.Id);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.HotelCategory), request.Id);
            }

            var validator = new UpdateHotelCategoryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateHotelCategoryCommand), typeof(TravelOoty.Domain.Entities.HotelCategory));

            await _amenitiesRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }

    }
}
