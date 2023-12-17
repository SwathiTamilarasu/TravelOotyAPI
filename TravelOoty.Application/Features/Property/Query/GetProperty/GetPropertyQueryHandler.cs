using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Property.Query.GetProperty
{
    public class GetPropertyQueryHandler: IRequestHandler<GetPropertyQuery, List<PropertyListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _asyncRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetPropertyQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> asyncRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _propertyRepository = propertyRepository;
        }
        public async Task<List<PropertyListVM>> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            //var allHotelCategory = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Name);
            //return _mapper.Map<List<PropertyListVM>>(allHotelCategory);

            var allHotelCategory = await _propertyRepository.GetPropertyList(request.Filter);
            return allHotelCategory;
        }
    }
}
