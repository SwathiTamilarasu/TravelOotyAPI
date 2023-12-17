using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Models.Mail;
using TravelOoty.Domain.Entities;

namespace TravelOoty.Infrastructure.Mail
{
    public class EmailService: IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient("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");
            var subject = email.Subject;
            var templateId = email.Subject == "Booking is Cancelled"? "d-276b49c38b3743d584c79d0983cbdfe2" : "d-fc88ee18450346719be0a70d9a9b4d44";
                   
            if(!string.IsNullOrEmpty(email.OwnerEmail))
            {
                var to = new List<EmailAddress>
                {

                   new EmailAddress("info@travelooty.in"),
                   new EmailAddress(email.OwnerEmail),
                   };
                var from = new EmailAddress
                {
                    Email = _emailSettings.FromAddress,
                    Name = _emailSettings.FromName,
                   

                };
                var dynamicTemplateData = new
                {
                    Booking_Id=email.BookingTemplate.BookingId,
                    Resort_Customer_Name = email.BookingTemplate.ResortName,
                    First_Name = email.BookingTemplate.FirstName,
                    Resort_Name = email.BookingTemplate.ResortName,
                    CheckInTime = email.BookingTemplate.CheckInTime,
                    CheckOutTime = email.BookingTemplate.CheckOutTime,
                    Your_Reservation = email.BookingTemplate.Reservation,
                    Member_Count = email.BookingTemplate.MemberCount,
                    Location = email.BookingTemplate.Location,
                    Phone = email.BookingTemplate.Phone,
                    Arrival_Time = email.BookingTemplate.ArrivalTime,
                    Cancellation_Policy = email.BookingTemplate.CancellationPolicy,
                    Special_Request = email.BookingTemplate.SpecialRequest,
                    Room_Price = email.BookingTemplate.RoomPrice,
                    Tax = email.BookingTemplate.Tax,
                    Total_Amt = email.BookingTemplate.TotalAmount,
                    CancellationUri = email.BookingTemplate.CancellationUri,
                    RoomType=email.BookingTemplate.RoomType,
                    NoOfNights=email.BookingTemplate.NoOfNights,
                    subject= email.Subject,
                    Customer_Name=email.BookingTemplate.CustomerName,
                    Payment_Mode=email.BookingTemplate.PaymentMode,
                    Body_Header = email.Subject == "Booking is Cancelled" ? "YOUR BOOKING IS CANCELLED." : "We are delighted to confirm your reservation details as follows:",
                };

                var sendGridMessage=  MailHelper.CreateSingleTemplateEmailToMultipleRecipients(from, to, templateId, dynamicTemplateData);
                var response = await client.SendEmailAsync(sendGridMessage);
                //if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                //    return true;
                //return false;
            }
            if (!string.IsNullOrEmpty(email.To))
            {
                var to = new List<EmailAddress>
                {

                   new EmailAddress("info@travelooty.in"),
                   new EmailAddress(email.To),

                };
                var from = new EmailAddress
                {
                    Email = _emailSettings.FromAddress,
                    Name = _emailSettings.FromName,

                };
                var dynamicTemplateData = new
                {
                    Resort_Customer_Name=email.BookingTemplate.FirstName,
                    First_Name = email.BookingTemplate.FirstName,
                    Resort_Name = email.BookingTemplate.ResortName,
                    CheckInTime = email.BookingTemplate.CheckInTime,
                    CheckOutTime = email.BookingTemplate.CheckOutTime,
                    Your_Reservation = email.BookingTemplate.Reservation,
                    Member_Count = email.BookingTemplate.MemberCount,
                    Location = email.BookingTemplate.Location,
                    Phone = email.BookingTemplate.Phone,
                    Arrival_Time = email.BookingTemplate.ArrivalTime,
                    Cancellation_Policy = email.BookingTemplate.CancellationPolicy,
                    Special_Request = email.BookingTemplate.SpecialRequest,
                    Room_Price = email.BookingTemplate.RoomPrice,
                    Tax = email.BookingTemplate.Tax,
                    Total_Amt = email.BookingTemplate.TotalAmount,
                    CancellationUri = email.BookingTemplate.CancellationUri,
                    RoomType = email.BookingTemplate.RoomType,
                    NoOfNights = email.BookingTemplate.NoOfNights,
                    subject = email.Subject,
                    Payment_Mode = email.BookingTemplate.PaymentMode,
                    Customer_Name = email.BookingTemplate.CustomerName,
                    Body_Header = email.Subject == "Booking is Cancelled" ? "YOUR BOOKING IS CANCELLED." : "We are delighted to confirm your reservation details as follows:",
                };
                var sendGridMessage = MailHelper.CreateSingleTemplateEmailToMultipleRecipients(from, to, templateId, dynamicTemplateData);
                var response = await client.SendEmailAsync(sendGridMessage);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SendPasswordEmail(Email email)
        {
            var subject = email.Subject;
            var client = new SendGridClient("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");
            var to = new EmailAddress(email.To);
            var body = email.Body;
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName,

            };
            var templateId = "d-7cbbf0afda9b4ddc92c3ea710b30c923";
            var dynamicTemplateData = new
            {
                action_url = email.Body
            };
                var sendGridMessage = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
            var response = await client.SendEmailAsync(sendGridMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                return true;
            return false;
        }
    }

}
