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

namespace TravelOoty.Application.Features.RoomsImageDetails.Query.GetAlImageById
{
    public class GetRoomImageQueryByIdHandler: IRequestHandler<GetRoomImageQueryById, List<RoomImageVM>>

    {
        private readonly IRoomImageRepository _roomImageRepository;
        private readonly IMapper _mapper;

        public GetRoomImageQueryByIdHandler(IMapper mapper, IRoomImageRepository roomImageRepository)
        {
            _mapper = mapper;
            _roomImageRepository = roomImageRepository;
            
        }
        public async Task<List<RoomImageVM>> Handle(GetRoomImageQueryById request, CancellationToken cancellationToken)
        {

            var allRooms = (await _roomImageRepository.GetRoomImageByIdAsyc(request.RoomId));
           
            if (allRooms == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Rooms), request.RoomId);
            }
            var result = new List<RoomImageVM>();
            if (allRooms.Count != 0)
            {
                foreach (var roomImage in allRooms)
                {
                    result.Add(new RoomImageVM { Id=roomImage.Id,RoomId=roomImage.RoomId,
                        ImageName=roomImage.ImageName,ImagePath=roomImage.ImagePath,Data_url=roomImage.ImagePath});
                }
            }
            return result;

        }
    }
}
