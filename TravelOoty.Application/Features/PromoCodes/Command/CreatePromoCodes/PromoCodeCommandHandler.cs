using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.City.Command.CreateCity;
using TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory;

namespace TravelOoty.Application.Features.PromoCodes.Command.CreatePromoCodes
{
    public class PromoCodeCommandHandler: IRequestHandler<PromoCodesCommand, PromoCodeCommandResponse>
    {
        private readonly IPromoCodeRepository _promoRepository;
        private readonly IMapper _mapper;
        public PromoCodeCommandHandler(IMapper mapper, IPromoCodeRepository promoRepository)
        {
            _mapper = mapper;
            _promoRepository = promoRepository;
        }

        public async Task<PromoCodeCommandResponse> Handle(PromoCodesCommand request, CancellationToken cancellationToken)
        {
            var createPromoCodeCommandResponse = new PromoCodeCommandResponse();

          
            
                var @promo = _mapper.Map<TravelOoty.Domain.Entities.PromoCode>(request);
                @promo = await _promoRepository.AddAsync(@promo);
            createPromoCodeCommandResponse.PromoCodeDto = _mapper.Map<PromoCodesDto>(@promo);
            
            return createPromoCodeCommandResponse;
        }
    }
}
