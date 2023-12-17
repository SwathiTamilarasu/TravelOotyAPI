using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Models.Mail;

namespace TravelOoty.Application.Features.Bookings.Command.CreateBooking
{
    public class CreateBookingHandler: IRequestHandler<CreateBookingCommand, CreateBookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateBookingHandler> _logger;
        private readonly IRoomRepository _roomRepository;

        public CreateBookingHandler(IMapper mapper, IRoomRepository roomRepository, IBookingRepository bookingRepository, IPropertyRepository propertyRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _emailService = emailService;
            _propertyRepository = propertyRepository;
            _roomRepository = roomRepository;



    }
        public async Task<CreateBookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var createBookingResponse = new CreateBookingResponse();
            if (request.TotalAmount == 0) {
                var roomRent = await _bookingRepository.GetRoomRent(request.RoomBookings.FirstOrDefault().RoomId);
                
                    request.TotalAmount = roomRent;
                
            }
            var propertyDetails = await _propertyRepository.GetPropertyByRoomIdAsync(request.RoomBookings.FirstOrDefault().RoomId);


            var @booking = _mapper.Map<TravelOoty.Domain.Entities.Booking>(request);
            @booking = await _bookingRepository.AddAsync(@booking);
            var roomRepo = await _roomRepository.GetRoomsByRoomIdAsync(request.RoomBookings.FirstOrDefault().RoomId.ToString());
            var bookingTemplate = new BookingTemplate();
            bookingTemplate.FirstName = @booking.FirstName;
            bookingTemplate.ResortName = propertyDetails.Name;
            bookingTemplate.CheckInTime = @booking.CheckIn.Date.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);
            bookingTemplate.CheckOutTime = @booking.CheckOut.Date.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);
            bookingTemplate.Reservation = roomRepo.RoomCategory.Name;
            bookingTemplate.MemberCount = @booking.RoomBookings.Count.ToString();
            bookingTemplate.Location = propertyDetails.Address;
            bookingTemplate.Phone = booking.PhoneNumber;
            bookingTemplate.Email=propertyDetails.Email;
            bookingTemplate.ArrivalTime = @booking.ArrivalTime;
            bookingTemplate.CancellationPolicy = roomRepo.CancellationPolicy;
            bookingTemplate.SpecialRequest = booking.SpecialRequest;
            var result = Convert.ToDecimal(propertyDetails.Tax / 100);
            bookingTemplate.TotalAmount = booking.TotalAmount.ToString();
            bookingTemplate.Tax = propertyDetails.Tax.ToString() + "%" ;
            bookingTemplate.RoomPrice = roomRepo.RegularPrice.ToString();
            bookingTemplate.NoOfNights = ((booking.CheckOut - booking.CheckIn).TotalDays).ToString() + " night, " + @booking.RoomBookings.Count.ToString() + " room, " + roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.RoomType = roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.CancellationUri = new Uri("https://travelooty.in/bookingcancellation?booking_id=" + @booking.BookingId);
            bookingTemplate.PaymentMode = booking.PayAtHotel ? "Pay at hotel" : "online";
            bookingTemplate.CustomerName = $"{booking.FirstName} {booking.LastName}";
            var email = new Email() { To = @booking.EmailId, OwnerEmail= propertyDetails.Email, Body = $"Greetings!", Subject = "Booking Confirmed",BookingTemplate=bookingTemplate
            };
            try
            {
                if (request.PayAtHotel)
                {
                    await _emailService.SendEmail(email);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about event {@booking.EmailId} failed due to an error with the mail service: {ex.Message}");
            }
            createBookingResponse.BookingDto = _mapper.Map<BookingDto>(@booking);
            return createBookingResponse;
        }
    }
}
