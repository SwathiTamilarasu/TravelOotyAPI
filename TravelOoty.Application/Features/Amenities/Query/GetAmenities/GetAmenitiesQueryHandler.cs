using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Amenities.Query.GetAmenities
{
    public class GetAmenitiesQueryHandler: IRequestHandler<GetAmenitiesQuery, List<AmenitiesListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Amenities> _amenitieslRepository;
        private readonly IMapper _mapper;
        public GetAmenitiesQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Amenities> amenitieslRepository)
        {
            _mapper = mapper;
            _amenitieslRepository = amenitieslRepository;
        }
        public async Task<List<AmenitiesListVM>> Handle(GetAmenitiesQuery request, CancellationToken cancellationToken)
        {
            var allAmenities = (await _amenitieslRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<AmenitiesListVM>>(allAmenities);
        }
    }
}
