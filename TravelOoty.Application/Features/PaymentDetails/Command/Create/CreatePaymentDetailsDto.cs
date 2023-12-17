using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PaymentDetails.Command.Create
{
    public class CreatePaymentDetailsDto
    {
        public int PaymentDetailsId { get; set; }
        public int BookingId { get; set; }
        public string PaymentId { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public string BankReference { get; set; }
        public string PaymentGroup { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
