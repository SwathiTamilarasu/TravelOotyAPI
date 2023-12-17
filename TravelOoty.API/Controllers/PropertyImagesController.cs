using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyImageDetails.Command;
using TravelOoty.Application.Features.PropertyImageDetails.Command.DeletePropertyImage;
using TravelOoty.Application.Features.PropertyImageDetails.Command.UpdatePropertyImage;
using TravelOoty.Application.Features.PropertyImageDetails.Query.GetAlImagesById;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetPropertyImage")]
        [HttpGet]
        public async Task<IActionResult> Get(int propertyId)
        {
            var result = await _mediator.Send(new GetPropImageQuery(propertyId));

            return Ok(result);
        }


        [Route("UploadPropertyImage")]
        [HttpPost]
        public async Task<IActionResult> UploadPhotoAsync([FromForm] UploadPropImageCommand uploadPropImageCommand)
        {
            var result = await _mediator.Send(uploadPropImageCommand);
            return Ok(result);
        }
        [Route("UpdatePropertyImage")]
        [HttpPut]
        public async Task<IActionResult> UpdatePhotoAsync([FromForm] UpdatePropImageCommand updateRoomImageCommand)
        {
            var result = await _mediator.Send(updateRoomImageCommand);
            return Ok(result);
        }

        [Route("DeletePropertyImage")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRoomImageCommand = new DeletePropImageCommand() { Id = id };
            await _mediator.Send(deleteRoomImageCommand);
            return Ok();
        }
    }
}
