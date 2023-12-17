using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Amenities.Commands.CreateAmenities;
using TravelOoty.Application.Features.Amenities.Commands.DeleteAmenities;
using TravelOoty.Application.Features.Amenities.Commands.UpdateAmenities;
using TravelOoty.Application.Features.Amenities.Query.GetAmenities;

namespace TravelOoty.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AmenitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AmenitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllAmenities")]
        //[Authorize(Roles = "Super Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<AmenitiesListVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetAmenitiesQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddAmenities")]
        public async Task<ActionResult<CreateAmenitiesCommandResponse>> Create([FromBody] CreateAmenitiesCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }
        [HttpPut(Name = "UpdateAmenities")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAmenitiesCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAmenities")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeleteAmenitiesCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
