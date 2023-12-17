using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features
{
    public class GetHotelsListQueryHandler: IRequestHandler<GetHotelsListQuery,List<HotelsListVM>>
    {
        private readonly IAsyncRespository<Hotel> _hotelRepository;
        private readonly IMapper _mapper;
        public GetHotelsListQueryHandler(IMapper mapper, IAsyncRespository<Hotel> hotelRespository)
        {
            _mapper = mapper;   
            _hotelRepository=hotelRespository;
        }
        public async Task<List<HotelsListVM>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken  )
        {
            var allHotels = (await _hotelRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<HotelsListVM>>(allHotels);
        }
    }
}
