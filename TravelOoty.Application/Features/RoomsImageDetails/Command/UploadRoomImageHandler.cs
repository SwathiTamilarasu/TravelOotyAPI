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
using TravelOoty.Application.Features.RoomsImageDetails.Query;

namespace TravelOoty.Application.Features.RoomsImageDetails.Command
{
    public class UploadRoomImageHandler: IRequestHandler<UploadRoomImageCommand,RoomImageVM>
    {
        private readonly IRoomImageRepository _roomImageRepository;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public UploadRoomImageHandler(IMapper mapper, IRoomImageRepository roomImageRepository, IBlobService blobService)
        {
            _mapper = mapper;
            _roomImageRepository = roomImageRepository;
            _blobService = blobService;
        }
        public async Task<RoomImageVM> Handle(UploadRoomImageCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _roomImageRepository.GetRoomsByRoomIdAsync(request.RoomId.ToString());

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Rooms), request.RoomId);
            }

            
            var imageResponse = await _blobService.UploadImageToBlobAsync(eventToUpdate.PropertyID + "-" + "rooms", request.File.OpenReadStream(), request.File.ContentType,
                                               request.File.FileName);


            //_mapper.Map(request, eventToUpdate, typeof(UploadRoomImageCommand), typeof(TravelOoty.Domain.Entities.Rooms));
            var roomImageCommand = new RoomImageVM();
            roomImageCommand.ImageName= imageResponse.ImageName;
            roomImageCommand.ImagePath = imageResponse.ImageUri.ToString();
            roomImageCommand.RoomId = eventToUpdate.RoomId;
            roomImageCommand.Data_url = imageResponse.ImageUri.ToString();
            //eventToUpdate.ImageName = imageResponse.ImageName;
            //eventToUpdate.ImagePath = imageResponse.ImageUri.ToString();
            await _roomImageRepository.AddAsync(_mapper.Map<TravelOoty.Domain.Entities.RoomImageDetails>(roomImageCommand));
            return roomImageCommand;
        }
    }
}
