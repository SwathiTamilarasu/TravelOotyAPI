using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory;
using TravelOoty.Application.Features.RoomCategory.Command.DeleteRoomCategory;
using TravelOoty.Application.Features.RoomCategory.Command.UpdateRoomCategory;
using TravelOoty.Application.Features.RoomCategory.Query.GetRoomCategory;
using TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Command.DeleteRoomFacility;
using TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllRoomCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<RoomCategoryVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetRoomCategoryQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddRoomCategory")]
        public async Task<ActionResult<CreateRoomCategoryCommandResponse>> Create([FromBody] CreateRoomCategoryCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }

        [HttpPut(Name = "UpdateRoomCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoomCategoryCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteRoomCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeleteRoomCategoryCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
