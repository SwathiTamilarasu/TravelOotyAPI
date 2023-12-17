using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.RoomCategory.Query.GetRoomCategory
{
  
    public class GetRoomCategoryQueryHandler : IRequestHandler<GetRoomCategoryQuery, List<RoomCategoryVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> _hotelCategoryRepository;
        private readonly IMapper _mapper;
        public GetRoomCategoryQueryHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.RoomCategory> roomCategoryRepository)
        {
            _mapper = mapper;
            _hotelCategoryRepository = roomCategoryRepository;
        }
        public async Task<List<RoomCategoryVM>> Handle(GetRoomCategoryQuery request, CancellationToken cancellationToken)
        {
            var allHotelCategory = (await _hotelCategoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<RoomCategoryVM>>(allHotelCategory);
        }
    }
}
