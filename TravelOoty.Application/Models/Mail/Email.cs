using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Mail
{
    public class Email
    {
        public string To { get; set; }
        public string OwnerEmail { get;set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string HtmlContent { get; set; }
        public  BookingTemplate BookingTemplate { get; set; }
    }
    public class BookingTemplate
    {
        public string BookingId { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string ResortName { get; set; }
        public string CheckInTime { get;set; }
        public string CheckOutTime { get;set; }
        public string Reservation { get;set;}
        public string MemberCount { get;set;}
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ArrivalTime { get; set; }
        public string CancellationPolicy { get; set; }
        public string SpecialRequest { get; set; }
        public string RoomPrice { get; set; }
        public string Tax { get; set; }
        public string TotalAmount { get; set; }
        public string RoomType { get; set; }
        public string NoOfNights { get; set; }
        public string PaymentMode { get; set; }
        public string CustomerName { get; set; }
        public Uri CancellationUri { get; set; }
        


    }
}
