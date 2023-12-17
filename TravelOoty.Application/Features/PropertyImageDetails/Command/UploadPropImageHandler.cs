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

namespace TravelOoty.Application.Features.PropertyImageDetails.Command
{
    public class UploadPropImageHandler: IRequestHandler<UploadPropImageCommand, PropertyImageVM>
    {
        private readonly IPropertyImageRepository _propImageRepository;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public UploadPropImageHandler(IMapper mapper, IPropertyImageRepository propImageRepository, IBlobService blobService)
        {
            _mapper = mapper;
            _propImageRepository = propImageRepository;
            _blobService = blobService;
        }
        public async Task<PropertyImageVM> Handle(UploadPropImageCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _propImageRepository.GetPropertyByPropertyIdAsync(request.PropertyId.ToString());

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.PropertyImageDetails), request.PropertyId);
            }


            var imageResponse = await _blobService.UploadImageToBlobAsync(eventToUpdate.PropertyID + "-" + "property", request.File.OpenReadStream(), request.File.ContentType,
                                               request.File.FileName);
            
            var propImageCommand = new PropertyImageVM();
            propImageCommand.ImageName = imageResponse.ImageName;
            propImageCommand.ImagePath = imageResponse.ImageUri.ToString();
            propImageCommand.PropertyId = eventToUpdate.PropertyID;
            propImageCommand.Data_url = imageResponse.ImageUri.ToString();           
            await _propImageRepository.AddAsync(_mapper.Map<TravelOoty.Domain.Entities.PropertyImageDetails>(propImageCommand));
            return propImageCommand;
        }

    }
}
