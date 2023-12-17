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
using TravelOoty.Application.Features.RoomCategory.Command.DeleteRoomCategory;

namespace TravelOoty.Application.Features.Property.Command.DeleteProperty
{
    public class DeletePropertyHandler : IRequestHandler<DeletePropertyCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _asyncRepository;
        private readonly IMapper _mapper;

        public DeletePropertyHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _asyncRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyType), request.Id);
            }

            await _asyncRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }


    }
    }
