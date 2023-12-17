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

namespace TravelOoty.Application.Features.HotelCategory.Commands.DeleteHotelCategory
{
    public class DeleteHotelCategoryHandler : IRequestHandler<DeleteHotelCategoryCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> _asyncRepository;
        private readonly IMapper _mapper;

        public DeleteHotelCategoryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeleteHotelCategoryCommand request, CancellationToken cancellationToken)
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
