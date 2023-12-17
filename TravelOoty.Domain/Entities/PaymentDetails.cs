using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class PaymentDetails: AuditableEntity
    {
        public int PaymentDetailsId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public string PaymentId { get;set; }
        public string PaymentAmount { get;set; }
        public string PaymentCurrency { get; set; }
        public string BankReference { get; set; }
        public string PaymentGroup { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
