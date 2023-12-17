using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Persistance;
using TravelOoty.Application.Models.Mail;

namespace TravelOoty.Application.Features.PaymentDetails.Command.Create
{
    public class CreatePaymentDetailsHandler: IRequestHandler<CreatePaymentDetailsCommand, CreatePaymentDetailsResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public CreatePaymentDetailsHandler(IMapper mapper, IPaymentRepository paymentRepository, IBookingRepository bookingRepository, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _propertyRepository = propertyRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<CreatePaymentDetailsResponse> Handle(CreatePaymentDetailsCommand request, CancellationToken cancellationToken)
        {
            var createRoomCategoryCommandResponse = new CreatePaymentDetailsResponse();

        //    var validator = new CreateRoomCategoryCommandValidator(_paymentRepository);
            //var validationResult = await validator.ValidateAsync(request);
            //if (validationResult.Errors.Count > 0)
            //{
            //    createRoomCategoryCommandResponse.Success = false;
            //    createRoomCategoryCommandResponse.ValidationErrors = new List<string>();
            //    foreach (var error in validationResult.Errors)
            //    {
            //        createRoomCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            //    }

            //}
            //if (createRoomCategoryCommandResponse.Success)
            //{
                var @paymentDetails = _mapper.Map<TravelOoty.Domain.Entities.PaymentDetails>(request);
                 @paymentDetails = await _paymentRepository.AddAsync(@paymentDetails);
                createRoomCategoryCommandResponse.CreatePaymentDetailsDto = _mapper.Map<CreatePaymentDetailsDto>(@paymentDetails);
            var bookingdetails = await _bookingRepository.GetBookingListByIdAsync(request.BookingId);
            var propertyDetails = await _propertyRepository.GetPropertyByRoomIdAsync(bookingdetails.RoomBookings.FirstOrDefault().RoomId);
           

            //var @booking = _mapper.Map<TravelOoty.Domain.Entities.Booking>(request);
            //@booking = await _bookingRepository.AddAsync(@booking);
            var email = new Email()
            {
                To = bookingdetails.EmailId,
                OwnerEmail = propertyDetails.Email,
                Body = $"Greetings!",
                Subject = "Booking Confirmed",
                HtmlContent =
            "<h1> Thanks " + bookingdetails.FirstName + "! Your booking is confirmed at " + propertyDetails.Name +"</h1>" +
"<h3> Reservation details </h3>" +
                "<div>" +
                "<div>" +
    "<p> Check -in</p><p>" + bookingdetails.CheckIn.Date.ToString("dd/MM/yyyy") + "</p>" +
                "</div>" +
                "<hr>" +
"<div>" +
    "<p> Check -out</p><p>" + bookingdetails.CheckOut.Date.ToString("dd/MM/yyyy") + "</p>" +
                "</div>" +
                "<hr>" +
"<div>" +
    "<p> Your reservation </p><p>" + bookingdetails.RoomBookings.Count + " </p>" +
     "</div>" +
"<hr>" +

"<hr>" +
"<div>" +
 "<p> Location </p><p>" + propertyDetails.Address + " </p>" +
"</div>" +
" <hr>" +
"<div>" +
    "<p> Phone </p>" + "<p>" + propertyDetails.PhoneNumber + "</p>" +
"</div>" +
"<hr>" +
                "<div>" +
    "<p> Email </p><p>" + propertyDetails.Email + "</p>" +
"</div>" +
"<hr>" +
"<div>" +
    "<p> Esttimated arrival time </p><p>" + bookingdetails.ArrivalTime + "</p>" +
"</div>" +
"<hr>" +
"<div>" +
    "<p> Cancellation policy </p><p> free Cancellation policy </p>" +
"</div>" +
"<hr>" +
"<div>" +
    "<p> Special Request </p><p> No reqest </p>" +
                "</div>" +
"</div>" +
"<br>" +
"<h3> Price details </h3>" +
"<div>" +

"<div>" +
 "<p> Total Amt </p><p>" + bookingdetails.TotalAmount + "</p>" +
"</div>" +
"</div>" +
"<br>" +
"<div>" +
"<h2> Travel Ooty </h2>" +
"<p> 4 / 118 B, Kagguchi village" +
    "kagguchi Post, The Nilgiris - 643214.</p>" +
    "<p> Copyright © 2022 travelooty.in. All rights reserved.</p>" +
    "<p> When communicating with your booked accommodation via travelooty.in you agree with the processing of the communications as set out in our Privacy Policy.</p>" +
    "<p> For any Queries Call us at(24 / 7) : +91 77080 66550, +91 96002 07309 </p>" +
"</div>"
            };

            //  }
            return createRoomCategoryCommandResponse;
        }
    }
}
