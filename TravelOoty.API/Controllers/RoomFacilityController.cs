using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Command.DeleteRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Query.GetRoomFacilty;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFacilityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomFacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllRoomFacility")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<RoomFacilityListVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetRoomFacilityQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddRoomFacility")]
        public async Task<ActionResult<CreateRoomFacilityResponse>> Create([FromBody] CreateRoomFacilityCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }

        [HttpPut(Name = "UpdateRoomFacility")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoomFacilityCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteRoomFacility")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeleteRoomFacilityCommand() { RoomFacilityId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
