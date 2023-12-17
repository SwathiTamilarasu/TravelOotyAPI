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

namespace TravelOoty.Application.Features.Property.Command.UpdateProperty
{
    public class UpdatePropertyHandler: IRequestHandler<UpdatePropertyCmd>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public UpdatePropertyHandler(IMapper mapper, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }
        public async Task<Unit> Handle(UpdatePropertyCmd request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _propertyRepository.GetPropertyToUpdateById(request.PropertyID);
            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Property), request.PropertyID);
            }

            _mapper.Map(request, eventToUpdate, typeof(UpdatePropertyCmd), typeof(TravelOoty.Domain.Entities.Property));
         

            await _propertyRepository.UpdatePropertyAsync(_mapper.Map<TravelOoty.Domain.Entities.Property>(eventToUpdate));

            return Unit.Value;
        }
    }
}
