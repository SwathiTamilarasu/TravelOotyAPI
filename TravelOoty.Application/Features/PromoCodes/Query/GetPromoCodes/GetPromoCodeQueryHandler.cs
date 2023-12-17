using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory;

namespace TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes
{
    public class GetPromoCodeQueryHandler: IRequestHandler<GetPromoCodeQuery, List<PromoCodeVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> _promoRepository;
        private readonly IMapper _mapper;
        public GetPromoCodeQueryHandler(IMapper mapper,IAsyncRespository<TravelOoty.Domain.Entities.PromoCode> promoRepository) 
        {
            _mapper = mapper;
            _promoRepository = promoRepository;
        }
        public async Task<List<PromoCodeVM>> Handle(GetPromoCodeQuery request, CancellationToken cancellationToken)
        {
            var promoCategory = await _promoRepository.ListAllAsync();
            return _mapper.Map<List<PromoCodeVM>>(promoCategory);
        }
    }
}
