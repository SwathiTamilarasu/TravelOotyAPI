using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PaymentDetails.Command.Create
{
    public class CreatePaymentDetailsCommand: IRequest<CreatePaymentDetailsResponse>
    {
        
        public int PaymentDetailsId { get; set; }
        [JsonPropertyName("order_id")]
        public int BookingId { get; set; }
        [JsonPropertyName("cf_payment_id")]
        public string PaymentId { get; set; }
        [JsonPropertyName("payment_amount")]
        public string PaymentAmount { get; set; }
        [JsonPropertyName("payment_currency")]
        public string PaymentCurrency { get; set; }
        [JsonPropertyName("bank_reference")]
        public string BankReference { get; set; }
        [JsonPropertyName("payment_group")]
        public string PaymentGroup { get; set; }
        [JsonPropertyName("payment_status")]
        public bool PaymentStatus { get; set; }
    }
}
