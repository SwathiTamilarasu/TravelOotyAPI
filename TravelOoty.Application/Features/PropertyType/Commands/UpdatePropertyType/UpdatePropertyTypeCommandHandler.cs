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

namespace TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType
{
    public class UpdatePropertyTypeCommandHandler: IRequestHandler<UpdatePropertyTypeCommand, UpdatePropertyTypeCommandResponse>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> _eventRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        private readonly IMapper _mapper;

        public UpdatePropertyTypeCommandHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> eventRepository, IPropertyTypeRepository propertyTypeRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<UpdatePropertyTypeCommandResponse> Handle(UpdatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            var updatePropertyTypeCommandResponse = new UpdatePropertyTypeCommandResponse();
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            var validator = new UpdatePropertyTypeCommandValidator(_propertyTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updatePropertyTypeCommandResponse.Success = false;
                updatePropertyTypeCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updatePropertyTypeCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                
            }
            _mapper.Map(request, eventToUpdate, typeof(UpdatePropertyTypeCommand), typeof(TravelOoty.Domain.Entities.PropertyType));

            if (updatePropertyTypeCommandResponse.Success)
            {                
                await _propertyTypeRepository.UpdateAsync(eventToUpdate);
                updatePropertyTypeCommandResponse.PropertyTypeDto = _mapper.Map<UpdatePropertyTypeDto>(eventToUpdate);
            }

            await _eventRepository.UpdateAsync(eventToUpdate);

            return updatePropertyTypeCommandResponse;
        }
    }
}
