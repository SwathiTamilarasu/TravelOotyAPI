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

namespace TravelOoty.Application.Features.Amenities.Commands.DeleteAmenities
{
    public class DeleteAmenitiesHandler: IRequestHandler<DeleteAmenitiesCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Amenities> _amentiesRepository;
        private readonly IMapper _mapper;

        public DeleteAmenitiesHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Amenities> amentiesRepository)
        {
            _mapper = mapper;
            _amentiesRepository = amentiesRepository;
        }

        public async Task<Unit> Handle(DeleteAmenitiesCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _amentiesRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _amentiesRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
