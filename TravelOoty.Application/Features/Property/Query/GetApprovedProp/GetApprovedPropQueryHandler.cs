using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetApprovedProp
{
    public class GetApprovedPropQueryHandler : IRequestHandler<GetApprovedPropQuery, List<PropertyListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _asyncRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetApprovedPropQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> asyncRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _propertyRepository = propertyRepository;
        }
        public async Task<List<PropertyListVM>> Handle(GetApprovedPropQuery request, CancellationToken cancellationToken)
        {
            //var allHotelCategory = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Name);
            //return _mapper.Map<List<PropertyListVM>>(allHotelCategory);

            var allHotelCategory = await _propertyRepository.GetApprovedPropertyList(request.Filter);
            return allHotelCategory;
        }

    }
}
