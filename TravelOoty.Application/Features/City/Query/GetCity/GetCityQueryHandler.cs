using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.City.Query.GetCity
{
    public class GetCityQueryHandler: IRequestHandler<GetCityQuery, List<CityListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.City> _cityRepository;
        private readonly IMapper _mapper;
        public GetCityQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.City> cityRespository)
        {
            _mapper = mapper;
            _cityRepository = cityRespository;
        }
        public async Task<List<CityListVM>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var allRoomFacility = (await _cityRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CityListVM>>(allRoomFacility);
        }
    }
}
