using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Features.Amenities.Commands.DeleteAmenities;
using TravelOoty.Application.Features.Bookings.Query.GetBookingByUser;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Exceptions;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using TravelOoty.Application.Features.Bookings.Command.SendBookingDetails;
using System.Globalization;

namespace TravelOoty.Application.Features.Bookings.Command.CancelBooking
{
    public class CancelBookingByIdHandler : IRequestHandler<CancelBookingById>
    {
        private readonly IAsyncRespository<TravelOoty.Domain.Entities.Booking> _asyncRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IEmailService _emailService;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SendBookingDetailsCommand> _logger;

        public CancelBookingByIdHandler(IMapper mapper, IAsyncRespository<TravelOoty.Domain.Entities.Booking> asyncRepository, IBookingRepository bookingRepository, IEmailService emailService, IPropertyRepository propertyRepository, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _bookingRepository = bookingRepository;
            _emailService = emailService;
            _propertyRepository = propertyRepository;
            _roomRepository = roomRepository;
    }
        public async Task<Unit> Handle(CancelBookingById request, CancellationToken cancellationToken)
        {
            var result = await _bookingRepository.GetBookingById(request.BookingId);
            if (result == null)
            {
                throw new NotFoundException(nameof(TravelOoty.Domain.Entities.Booking), request.BookingId);
            }
            var bookingdetails = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            var propertyDetails = await _propertyRepository.GetPropertyByRoomIdAsync(bookingdetails.RoomBookings.FirstOrDefault().RoomId);

            var allBooking = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            var roomRepo = await _roomRepository.GetRoomsByRoomIdAsync(bookingdetails.RoomBookings.FirstOrDefault().RoomId.ToString());
            var bookingTemplate = new BookingTemplate();
            bookingTemplate.BookingId = allBooking.BookingId.ToString();
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
            bookingTemplate.NoOfNights = ((allBooking.CheckOut - allBooking.CheckIn).TotalDays).ToString() + " night, " + allBooking.RoomBookings.Count.ToString() + " room, " + roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.RoomType = roomRepo.RoomCategory.Name.ToString();
            bookingTemplate.CancellationUri = new Uri("https://travelooty.in/bookingcancellation?booking_id=" + allBooking.BookingId);
            bookingTemplate.PaymentMode = allBooking.PayAtHotel ? "Pay at hotel" : "online";
            bookingTemplate.CustomerName=$"{allBooking.FirstName} {allBooking.LastName}";
            var email = new Email()
            {
                To = allBooking.EmailId,
                OwnerEmail = propertyDetails.Email,
                Body = $"Greetings!",
                Subject = "Booking is Cancelled",
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

            await _bookingRepository.DeleteAsync(result);

            return Unit.Value;
        }
    }
}
