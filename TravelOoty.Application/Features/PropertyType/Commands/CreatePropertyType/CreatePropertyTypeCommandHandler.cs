using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType
{
    public class CreatePropertyTypeCommandHandler:IRequestHandler<CreatePropertyTypeCommand, CreatePropertyTypeCommandResponse>
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        private readonly IMapper _mapper;
        public CreatePropertyTypeCommandHandler(IMapper mapper, IPropertyTypeRepository propertyTypeRepository)
        {
            _mapper = mapper;
            _propertyTypeRepository = propertyTypeRepository;
            
        }

        public async Task<CreatePropertyTypeCommandResponse> Handle(CreatePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            var createPropertyTypeCommandResponse = new CreatePropertyTypeCommandResponse();

            var validator = new CreatePropertyTypeCommandValidator(_propertyTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createPropertyTypeCommandResponse.Success = false;
                createPropertyTypeCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPropertyTypeCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (createPropertyTypeCommandResponse.Success)
            {
                var @hotel = _mapper.Map<TravelOoty.Domain.Entities.PropertyType>(request);
                @hotel = await _propertyTypeRepository.AddAsync(@hotel);
                createPropertyTypeCommandResponse.PropertyTypeDto = _mapper.Map<CreatePropertyTypeDto>(@hotel);                                
            }
            return createPropertyTypeCommandResponse;
        }
    }
}
