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

namespace TravelOoty.Application.Features.PropertyImageDetails.Command.DeletePropertyImage
{
    public class DeletePropImageHandler: IRequestHandler<DeletePropImageCommand>
    {
        private readonly IPropertyImageRepository _propRepository;
        private readonly IMapper _mapper;
        public DeletePropImageHandler(IMapper mapper, IPropertyImageRepository propImageRepository)
        {
            _mapper = mapper;
            _propRepository = propImageRepository;
        }

        public async Task<Unit> Handle(DeletePropImageCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _propRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _propRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }
    }
}
