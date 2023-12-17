using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes;

namespace TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodesByName
{
    public class GetPromoCodeQueryNameHandler: IRequestHandler<GetPromoCodeByNameQuery,string>
    {
        private readonly IPromoCodeRepository _promoRepository;
        private readonly IMapper _mapper;
        public GetPromoCodeQueryNameHandler(IMapper mapper, IPromoCodeRepository promoRepository)
        {
            _mapper = mapper;
            _promoRepository = promoRepository;
        }
        public async Task<string> Handle(GetPromoCodeByNameQuery request, CancellationToken cancellationToken)
        {
            var promoCategory = await _promoRepository.IsPromoCodeValidReturnDiscount(request.Name);
            return _mapper.Map<string>(promoCategory);
        }
    }
}
