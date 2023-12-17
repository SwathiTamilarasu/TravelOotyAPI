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
using TravelOoty.Application.Features.Property.Command.DeleteProperty;

namespace TravelOoty.Application.Features.PromoCodes.Command.DeletePromoCodes
{
    public class DeletePromoCodesHandler: IRequestHandler<DeletePromoCodesCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> _asyncRepository;
        private readonly IMapper _mapper;

        public DeletePromoCodesHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Unit> Handle(DeletePromoCodesCommand request, CancellationToken cancellationToken)
        {
            var propertyTypeToDelete = await _asyncRepository.GetByIdAsync(request.Id);

            if (propertyTypeToDelete == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PromoCode), request.Id);
            }

            await _asyncRepository.DeleteAsync(propertyTypeToDelete);

            return Unit.Value;
        }

    }
}
