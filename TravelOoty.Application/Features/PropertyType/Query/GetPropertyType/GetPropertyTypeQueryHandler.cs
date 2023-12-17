using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.PropertyType.Query.GetPropertyType
{
    public class GetPropertyTypeQueryHandler: IRequestHandler<GetPropertyTypeQuery, List<PropertyTypeListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> _propertyTypelRepository;
        private readonly IMapper _mapper;
        public GetPropertyTypeQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.PropertyType> hotelRespository)
        {
            _mapper = mapper;
            _propertyTypelRepository = hotelRespository;
        }
        public async Task<List<PropertyTypeListVM>> Handle(GetPropertyTypeQuery request, CancellationToken cancellationToken)
        {
            var allHotels = (await _propertyTypelRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<PropertyTypeListVM>>(allHotels);
        }
    }
}
