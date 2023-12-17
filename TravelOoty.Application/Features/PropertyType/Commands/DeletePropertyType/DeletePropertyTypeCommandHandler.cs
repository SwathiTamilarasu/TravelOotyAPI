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

namespace TravelOoty.Application.Features.PropertyType.Commands.DeletePropertyType
{
    public class DeletePropertyTypeCommandHandler: IRequestHandler<DeletePropertyTypeCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> _eventRepository;
        private readonly IMapper _mapper;

        public DeletePropertyTypeCommandHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeletePropertyTypeCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _eventRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _eventRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
