using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features;
using TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType;
using TravelOoty.Application.Features.PropertyType.Commands.DeletePropertyType;
using TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType;
using TravelOoty.Application.Features.PropertyType.Query.GetPropertyType;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPropertyType")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<PropertyTypeListVM>>> GetAllPropertyType()
        {
            var dtos = await _mediator.Send(new GetPropertyTypeQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddPropertyType")]
        public async Task<ActionResult<CreatePropertyTypeCommandResponse>> Create([FromBody] CreatePropertyTypeCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }

        [HttpPut(Name = "UpdatePropertyType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePropertyTypeCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePropertyType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeletePropertyTypeCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
