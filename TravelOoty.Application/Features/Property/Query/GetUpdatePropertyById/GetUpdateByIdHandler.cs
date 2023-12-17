using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetUpdatePropertyById
{
    public class GetUpdateByIdHandler: IRequestHandler<GetUpdatePropertyId, UpdatePropertyCommand>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Property> _asyncRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetUpdateByIdHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Property> asyncRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _propertyRepository = propertyRepository;
        }
        public async Task<UpdatePropertyCommand> Handle(GetUpdatePropertyId request, CancellationToken cancellationToken)
        {
            var allHotelCategory = await _propertyRepository.GetPropertyByIdForPatch(request.PropertyId);
            return allHotelCategory;
        }
    }
}
