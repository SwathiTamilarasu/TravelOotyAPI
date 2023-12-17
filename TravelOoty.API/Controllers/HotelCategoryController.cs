using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory;
using TravelOoty.Application.Features.HotelCategory.Commands.DeleteHotelCategory;
using TravelOoty.Application.Features.HotelCategory.Commands.UpdateHotelCategory;
using TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllHotelCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<HotelCategoryVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetHotelCategoryQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddHotelCategory")]
        public async Task<ActionResult<CreateHotelCategoryCommandResponse>> Create([FromBody] CreateHotelCategoryCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }
        [HttpPut(Name = "UpdateHotelCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateHotelCategoryCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteHotelCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeleteHotelCategoryCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
