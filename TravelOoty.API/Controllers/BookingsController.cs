using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.API.Model;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Features.Bookings.Command.CancelBooking;
using TravelOoty.Application.Features.Bookings.Command.CreateBooking;
using TravelOoty.Application.Features.Bookings.Command.UpdateBooking;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Features.Bookings.Query.GetBookingByPropId;
using TravelOoty.Application.Features.Bookings.Query.GetBookingByUser;
using TravelOoty.Application.Features.Bookings.Query.GetRoomBookingsByDate;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;
        public BookingsController(IMediator mediator, IAuthenticationService authenticationService)
        {
            _mediator = mediator;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<BookingVM>>> Get()
        {
            var dtos = await _mediator.Send(new GetBookingQuery());
            return Ok(dtos);
        }

        //[HttpGet]
        [HttpGet("UserId", Name = "GetAllBookingByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<BookingVM>>> GetBookingByUser(string userId)
        {
            var userDetails = await _authenticationService.GetUserById(userId);
            var dtos = new List<BookingVM>();
            if (userDetails.isEmployee)
            {
                 dtos = await _mediator.Send(new GetBookingQueryByUser(userId,true));
            }
            else
            {
                 dtos = await _mediator.Send(new GetBookingQueryByUser(userId, false));
            }
            return Ok(dtos);
        }

        [HttpGet("PropertyId", Name = "GetAllBookingByPropertyID")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<BookingVM>>> GetBookingByPropertyId(int propertyId)
        {
            var dtos = await _mediator.Send(new GetBookingQueryByPropId(propertyId));
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookingResponse>> Create([FromBody] CreateBookingCommand createBookingCommand) 
        {
            var response = await _mediator.Send(createBookingCommand);
            //   return response;
            try
            {
                if (!createBookingCommand.PayAtHotel && createBookingCommand.isBlocked == null)
                {
                    HttpClient client = new HttpClient();
                    var orderDetails = new OrderDetails();
                    orderDetails.customer_details = new CustomerDetails();
                    orderDetails.order_meta = new OrderMeta { notify_url= "https://travelooty.in/transaction",
                        return_url= "https://travelooty.in/transaction?order_id={order_id}&order_token={order_token}" };
                    if (createBookingCommand.UserId != 0)
                    {
                        orderDetails.customer_details.customer_id = createBookingCommand.UserId.ToString();
                    }
                    else
                    {
                        orderDetails.customer_details.customer_id = Guid.NewGuid().ToString();
                    }
                    
                    orderDetails.customer_details.customer_email = createBookingCommand.EmailId;
                    orderDetails.customer_details.customer_phone = createBookingCommand.PhoneNumber;
                    orderDetails.order_id = response.BookingDto.BookingId.ToString();
                    orderDetails.order_amount = createBookingCommand.TotalAmount;
                    orderDetails.order_currency = createBookingCommand.OrderCurrency;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(orderDetails);
                    var data = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    string url = "https://api.cashfree.com/pg/orders";
                    client.DefaultRequestHeaders.Add("x-client-id", "2329003bf61b5c1217455bcb5b009232");
                    client.DefaultRequestHeaders.Add("x-client-secret", "4b59eb73c612326807af4592969470a8c9089760");
                    client.DefaultRequestHeaders.Add("x-api-version", "2022-01-01");
                    var orderResponse = await client.PostAsync(url, data);
                    var responseString = await orderResponse.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.DeserializeObject(responseString));
                }
                else
                {
                    return Ok(response);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetRoomByBookingDate/{roomId}/{fromDate}/{toDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetRoomBookingByDate>> GetRoomByBookingDate(int roomId,DateTime fromDate, DateTime toDate)
        {
            var dtos = await _mediator.Send(new GetRoomBookingByDate(roomId, fromDate, toDate));
            return Ok(dtos);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookingCommand updateBookingCommand)
        {
            await _mediator.Send(updateBookingCommand);
            return Ok();
        }

        [HttpDelete("BookingId", Name = "CancelBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> Delete(int bookingId)
        {
            var deleteEventCommand = new CancelBookingById() { BookingId = bookingId };
            await _mediator.Send(deleteEventCommand);
            return Ok();
        }
    }
}
