using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Amenities.Commands.CreateAmenities;
using TravelOoty.Application.Features.Bookings.Query;
using TravelOoty.Application.Features.PromoCodes.Command.CreatePromoCodes;
using TravelOoty.Application.Features.PromoCodes.Command.DeletePromoCodes;
using TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes;
using TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodesByName;
using TravelOoty.Application.Features.Property.Command.DeleteProperty;
using TravelOoty.Application.Features.Rooms.Query;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromoCodesController(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PromoCodeVM>>> Get()
        {
            var dtos = await _mediator.Send(new GetPromoCodeQuery());
            return Ok(dtos);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetPromoCodeByName(string name)
        {

            var dtos = await _mediator.Send(new GetPromoCodeByNameQuery(name));
            return Ok(dtos);
        }

        [HttpPost(Name = "AddPromoCode")]
        public async Task<ActionResult<PromoCodeCommandResponse>> Create([FromBody] PromoCodesCommand createPromoCodeCommand)
        {
            var response = await _mediator.Send(createPromoCodeCommand);
            return response;
        }
        [HttpDelete("{id}", Name = "DeletePromoCodes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeletePromoCodesCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
