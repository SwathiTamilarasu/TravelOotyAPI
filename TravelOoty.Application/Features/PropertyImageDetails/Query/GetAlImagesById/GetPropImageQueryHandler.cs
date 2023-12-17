using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Exceptions;

namespace TravelOoty.Application.Features.PropertyImageDetails.Query.GetAlImagesById
{
    public class GetPropImageQueryHandler: IRequestHandler<GetPropImageQuery, List<PropertyImageVM>>
    {
        private readonly IPropertyImageRepository _propImageRepository;
        private readonly IMapper _mapper;

        public GetPropImageQueryHandler(IMapper mapper, IPropertyImageRepository propImageRepository)
        {
            _mapper = mapper;
            _propImageRepository = propImageRepository;

        }
        public async Task<List<PropertyImageVM>> Handle(GetPropImageQuery request, CancellationToken cancellationToken)
        {

            var allProperty = (await _propImageRepository.GetPropertyImageByIdAsyc(request.PropertyId));

            if (allProperty == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyImageDetails), request.PropertyId);
            }
            var result = new List<PropertyImageVM>();
            if (allProperty.Count != 0)
            {
                foreach (var propImage in allProperty)
                {
                    result.Add(new PropertyImageVM
                    {
                        Id = propImage.Id,
                        PropertyId = propImage.PropertyId,
                        ImageName = propImage.ImageName,
                        ImagePath = propImage.ImagePath,
                        Data_url = propImage.ImagePath
                    });
                }
            }
            return result;
        }
    }
}
