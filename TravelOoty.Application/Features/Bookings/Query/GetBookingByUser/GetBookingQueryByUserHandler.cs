using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;

namespace TravelOoty.Application.Features.Bookings.Query.GetBookingByUser
{
    public class GetBookingQueryByUserHandler : IRequestHandler<GetBookingQueryByUser, List<BookingVM>>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Booking> _asyncRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetBookingQueryByUserHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Booking> asyncRepository, IBookingRepository bookingRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _bookingRepository = bookingRepository;
            _propertyRepository = propertyRepository;
        }
        public async Task<List<BookingVM>> Handle(GetBookingQueryByUser request, CancellationToken cancellationToken)
        {
            //var allHotelCategory = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Name);
            //return _mapper.Map<List<PropertyListVM>>(allHotelCategory);
            var allBooking=new List<BookingVM>();
            if (!request.IsEmployee)
            {
                allBooking = await _bookingRepository.GetBookingListByUserId(request.UserId);
            }
            else
            {
                if (string.IsNullOrEmpty(request.UserId))
                {
                    allBooking = await _bookingRepository.GetBookingList();
                }
                else
                {
                    var property = await _propertyRepository.GetPropertyByUserId(request.UserId);
                    allBooking = await _bookingRepository.GetBookingListByByPropId(property.PropertyID);
                }
            }
            return allBooking;
        }
    }
}
