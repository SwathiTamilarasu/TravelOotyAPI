using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelOoty.API.Model;
using TravelOoty.Application.Features.Bookings.Command.SendBookingDetails;
using TravelOoty.Application.Features.PaymentDetails.Command.Create;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{orderId}")]
        public async Task<ActionResult> Get(string orderId)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.cashfree.com/pg/orders/" + orderId + "/payments";
            client.DefaultRequestHeaders.Add("x-client-id", "2329003bf61b5c1217455bcb5b009232");
            client.DefaultRequestHeaders.Add("x-client-secret", "4b59eb73c612326807af4592969470a8c9089760");
            client.DefaultRequestHeaders.Add("x-api-version", "2022-01-01");
            var response = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<List<TravelOoty.API.Model.TransactionDetails>>(response);
            var paymentDetailsCommand = new CreatePaymentDetailsCommand();
            var finalResult = result[0];
            paymentDetailsCommand.PaymentAmount = finalResult.payment_amount;
            paymentDetailsCommand.PaymentCurrency = finalResult.payment_currency;
            paymentDetailsCommand.PaymentStatus = finalResult.payment_status == "SUCCESS" ? true : false;
            paymentDetailsCommand.BankReference = finalResult.bank_reference;
            paymentDetailsCommand.BookingId = Convert.ToInt32(finalResult.order_id);
            paymentDetailsCommand.PaymentGroup = finalResult.payment_group;
            paymentDetailsCommand.PaymentId = finalResult.cf_payment_id;
            var postResponse = await _mediator.Send(paymentDetailsCommand);
            var responseEmail = await _mediator.Send(new SendBookingDetailsCommand(Convert.ToInt32(orderId)));
            return Ok(finalResult);
            
        }
    }
}
