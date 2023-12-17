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

namespace TravelOoty.Application.Features.Property.Command.CreateProperty
{
    public class CreatePropertyHandler: IRequestHandler<CreatePropertyCommand, CreatePropertyResponse>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public CreatePropertyHandler(IMapper mapper, IPropertyRepository propertyRepository, IBlobService blobService)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
            _blobService = blobService;

        }

        public async Task<CreatePropertyResponse> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var createPropertyResponse = new CreatePropertyResponse();

            var validator = new CreatePropertyValidator(_propertyRepository);
            //var validationResult = await validator.ValidateAsync(request);
            //if (validationResult.Errors.Count > 0)
            //{
            //    createPropertyResponse.Success = false;
            //    createPropertyResponse.ValidationErrors = new List<string>();
            //    foreach (var error in validationResult.Errors)
            //    {
            //        createPropertyResponse.ValidationErrors.Add(error.ErrorMessage);
            //    }

            //}
            if (createPropertyResponse.Success)
            {                
                var @property = _mapper.Map<TravelOoty.Domain.Entities.Property>(request);
                @property = await _propertyRepository.AddAsync(@property);

                createPropertyResponse.PropertyDto = _mapper.Map<PropertyDto>(@property);
                if (request.File != null)
                {
                    var imageResponse = await _blobService.UploadImageToBlobAsync(createPropertyResponse.PropertyDto.PropertyID + '-' + "property",
                         request.File.OpenReadStream(), request.File.ContentType, request.File.FileName);
                    createPropertyResponse.PropertyDto.ImageName = imageResponse.ImageName;
                    createPropertyResponse.PropertyDto.ImagePath = imageResponse.ImageUri;
                    @property.ImagePath= imageResponse.ImageUri.ToString();
                    @property.ImageName = imageResponse.ImageName;
                    
                    //request.ImagePath = imageResponse.ImageUri;
                    //request.ImageName = imageResponse.ImageName;
                    //request.PropertyID = createPropertyResponse.PropertyDto.PropertyID;
                }
                //_mapper.Map(request, @property, typeof(CreatePropertyCommand), typeof(TravelOoty.Domain.Entities.Property));
                await _propertyRepository.UpdateAsync(_mapper.Map <TravelOoty.Domain.Entities.Property>(@property));
            }
            return createPropertyResponse;
        }
    }
}
