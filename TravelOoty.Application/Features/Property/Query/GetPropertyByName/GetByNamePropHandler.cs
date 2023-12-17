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
using TravelOoty.Application.Features.Property.Query.GetPropertyInfoById;

namespace TravelOoty.Application.Features.Property.Query.GetPropertyByName
{
    public class GetByNamePropHandler : IRequestHandler<GetPropQueryName, List<PropertyListVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _asyncRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetByNamePropHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> asyncRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _propertyRepository = propertyRepository;
        }
        public async Task<List<PropertyListVM>> Handle(GetPropQueryName request, CancellationToken cancellationToken)
        {
            var allHotelCategory = await _propertyRepository.GetPropertyInfoByName(request.Name);
            return allHotelCategory;
        }
    }
}
