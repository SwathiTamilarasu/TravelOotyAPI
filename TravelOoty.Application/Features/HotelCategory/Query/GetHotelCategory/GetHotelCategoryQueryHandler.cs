using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory
{
    public class GetHotelCategoryQueryHandler: IRequestHandler<GetHotelCategoryQuery, List<HotelCategoryVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> _hotelCategoryRepository;
        private readonly IMapper _mapper;
        public GetHotelCategoryQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.HotelCategory> hotelCategoryRepository)
        {
            _mapper = mapper;
            _hotelCategoryRepository = hotelCategoryRepository;
        }
        public async Task<List<HotelCategoryVM>> Handle(GetHotelCategoryQuery request, CancellationToken cancellationToken)
        {
            var allHotelCategory = (await _hotelCategoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<HotelCategoryVM>>(allHotelCategory);
        }
    }
}
