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
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Models.Mail;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Application.Features.Bookings.Command.SendBookingDetails
{
    public class SendBookingDetailsHandler : IRequestHandler<SendBookingDetailsCommand, BookingVM>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Booking> _asyncRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ILogger<SendBookingDetailsCommand> _logger;
        public SendBookingDetailsHandler(IMapper mapper, IRoomRepository roomRepository, IAsyncRespository<TravelOoty.Domain.Entities.Booking> asyncRepository, IPropertyRepository propertyRepository, IBookingRepository bookingRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _bookingRepository = bookingRepository;
            _emailService = emailService;
            _propertyRepository = propertyRepository;
            _roomRepository = roomRepository;
          
        }
        public async Task<BookingVM> Handle(SendBookingDetailsCommand request, CancellationToken cancellationToken)
        {
            var bookingdetails = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            var propertyDetails = await _propertyRepository.GetPropertyByRoomIdAsync(bookingdetails.RoomBookings.FirstOrDefault().RoomId);

            var allBooking = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            var roomRepo = await _roomRepository.GetRoomsByRoomIdAsync(bookingdetails.RoomBookings.FirstOrDefault().RoomId.ToString());
            var bookingTemplate = new BookingTemplate();
            bookingTemplate.FirstName = allBooking.FirstName;
            bookingTemplate.ResortName = propertyDetails.Name;
            bookingTemplate.CheckInTime = allBooking.CheckIn.Date.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);
            bookingTemplate.CheckOutTime = allBooking.CheckOut.Date.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);
            bookingTemplate.Reservation = roomRepo.RoomCategory.Name;
            bookingTemplate.MemberCount = allBooking.RoomBookings.Count.ToString();
            bookingTemplate.Location = propertyDetails.Address;
            bookingTemplate.Phone = allBooking.PhoneNumber;
            bookingTemplate.Email = propertyDetails.Email;
            bookingTemplate.ArrivalTime = allBooking.ArrivalTime;
            bookingTemplate.CancellationPolicy = roomRepo.CancellationPolicy;
            bookingTemplate.SpecialRequest = allBooking.SpecialRequest;
            bookingTemplate.TotalAmount = allBooking.TotalAmount.ToString();
            bookingTemplate.Tax = propertyDetails.Tax.ToString();
            bookingTemplate.RoomPrice = roomRepo.RegularPrice.ToString() + "%";
            bookingTemplate.NoOfNights= ((allBooking.CheckOut - allBooking.CheckIn).TotalDays).ToString() + " night, "+ allBooking.RoomBookings.Count.ToString() + " room, " + roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.RoomType = roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.CancellationUri = new Uri("https://travelooty.in/bookingcancellation?booking_id=" + allBooking.BookingId );
            bookingTemplate.PaymentMode = allBooking.PayAtHotel ? "Pay at hotel" : "online";
            bookingTemplate.CustomerName = $"{allBooking.FirstName} {allBooking.LastName}";
            var email = new Email()
            {
                To = allBooking.EmailId,
                OwnerEmail = propertyDetails.Email,
                Body = $"Greetings!",
                Subject = "Booking Confirmed",
                BookingTemplate = bookingTemplate
            };
            try
            {                
                    await _emailService.SendEmail(email);
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about event {allBooking.EmailId} failed due to an error with the mail service: {ex.Message}");
            }
            return _mapper.Map<BookingVM>(allBooking);
           
        }
    }
}
