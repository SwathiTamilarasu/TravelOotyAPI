using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.PaymentDetails.Command.Create
{
    public class CreatePaymentDetailsResponse: BaseResponse
    {
        public CreatePaymentDetailsResponse() : base()
        {

        }
        public CreatePaymentDetailsDto CreatePaymentDetailsDto { get; set; }
    }
}
