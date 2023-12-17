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

namespace TravelOoty.Application.Features.Bookings.Command.UpdateBooking
{
    public class UpdateBookingHandler: IRequestHandler<UpdateBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public UpdateBookingHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Rooms), request.BookingId);
            }
            if (request.TotalAmount == 0)
            {
                var roomRent = await _bookingRepository.GetRoomRent(eventToUpdate.RoomBookings.FirstOrDefault().RoomId);

                request.TotalAmount = roomRent;

            }
            if (request.TotalAmount > 0 && request.BookingId != 0 && request.isBlocked == false)
            {
                await _bookingRepository.DeleteAsync(eventToUpdate);
            }
            else
            {
                _mapper.Map(request, eventToUpdate, typeof(UpdateBookingCommand), typeof(TravelOoty.Domain.Entities.Booking));

                await _bookingRepository.UpdateAsync(_mapper.Map<TravelOoty.Domain.Entities.Booking>(eventToUpdate));
            }
            return Unit.Value;
          
        }
    }
}
