using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Exceptions;
using TravelOoty.Application.Features.PropertyImageDetails.Query;

namespace TravelOoty.Application.Features.PropertyImageDetails.Command.UpdatePropertyImage
{
    public class UpdatePropImageHandler: IRequestHandler<UpdatePropImageCommand>
    {
        private readonly IPropertyImageRepository _propImageRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public UpdatePropImageHandler(IMapper mapper, IPropertyImageRepository propImageRepository, IBlobService blobService, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propImageRepository = propImageRepository;
            _blobService = blobService;
            _propertyRepository = propertyRepository;
        }
        public async Task<Unit> Handle(UpdatePropImageCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _propImageRepository.GetPropertyForUpdateImageByIdAsyc(request.PropertyId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyImageDetails), request.PropertyId);
            }

            var imageResponse = await _blobService.UploadImageToBlobAsync(request.PropertyId + "-" + "property", request.File.OpenReadStream(), request.File.ContentType,
                                               request.File.FileName);
            request.Id = eventToUpdate.Id;
            request.ImageName = imageResponse.ImageName;
            request.ImagePath = imageResponse.ImageUri.ToString();
            _mapper.Map(request, eventToUpdate, typeof(UpdatePropImageCommand), typeof(TravelOoty.Domain.Entities.PropertyImageDetails));

            await _propImageRepository.UpdateAsync(_mapper.Map<TravelOoty.Domain.Entities.PropertyImageDetails>(eventToUpdate));
            
            var eventToUpdateProperty = await _propertyRepository.GetPropertyToUpdateById(request.PropertyId);
            eventToUpdateProperty.ImageName = imageResponse.ImageName;
            eventToUpdateProperty.ImagePath = imageResponse.ImageUri.ToString();
            await _propertyRepository.UpdateAsync(_mapper.Map<TravelOoty.Domain.Entities.Property>(eventToUpdateProperty));

            return Unit.Value;
        }
    }
}
