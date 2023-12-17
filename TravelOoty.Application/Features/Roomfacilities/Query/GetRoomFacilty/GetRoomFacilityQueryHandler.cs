using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Roomfacilities.Query.GetRoomFacilty
{
    public class GetRoomFacilityQueryHandler: IRequestHandler<GetRoomFacilityQuery, List<RoomFacilityListVM>>
    
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> _roomFacilitylRepository;
        private readonly IMapper _mapper;
        public GetRoomFacilityQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomFacility> roomFacilityRespository)
        {
            _mapper = mapper;
            _roomFacilitylRepository = roomFacilityRespository;
        }
        public async Task<List<RoomFacilityListVM>> Handle(GetRoomFacilityQuery request, CancellationToken cancellationToken)
        {
            var allRoomFacility = (await _roomFacilitylRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<RoomFacilityListVM>>(allRoomFacility);
        }
    }
}
