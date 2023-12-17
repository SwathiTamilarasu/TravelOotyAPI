using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Exceptions;
using TravelOoty.Application.Features.Property.Command.CreateProperty;

namespace TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval
{
    public class UpdatePropertyComandHandler : IRequestHandler<UpdatePropertyCommand, UpdatePropertyCommandResponse>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _commonRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public UpdatePropertyComandHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> commonRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<UpdatePropertyCommandResponse> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
           
        {
            var eventToUpdate = await _propertyRepository.GetPropEntityById(request.PropertyID);
            var updatePropertyCommandResponse = new UpdatePropertyCommandResponse();
            _mapper.Map(request, eventToUpdate, typeof(UpdatePropertyCommand), typeof(TravelOoty.Domain.Entities.Property));
            await _commonRepository.SaveChanges();           
            updatePropertyCommandResponse.PropertyDto = _mapper.Map<PropertyDto>(eventToUpdate);
            return _mapper.Map<UpdatePropertyCommandResponse>(eventToUpdate);
        }
    }
}
