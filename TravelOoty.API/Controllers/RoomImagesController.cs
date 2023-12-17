using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PropertyImageDetails.Command.UpdatePropertyImage;
using TravelOoty.Application.Features.RoomsImageDetails.Command;
using TravelOoty.Application.Features.RoomsImageDetails.Command.DeleteRoomImage;
using TravelOoty.Application.Features.RoomsImageDetails.Query.GetAlImageById;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetRoomImage")]
        [HttpGet]
        public async Task<IActionResult> Get(int RoomId)
        {
            var result= await _mediator.Send(new GetRoomImageQueryById(RoomId));
            
            return Ok(result);
        }


        [Route("UploadRoomImage")]
        [HttpPost]
        public async Task<IActionResult> UploadPhotoAsync([FromForm] UploadRoomImageCommand uploadRoomImageCommand)
        {
           var result= await _mediator.Send(uploadRoomImageCommand);
            return Ok(result);
        }
     
        [Route("DeleteRoomImage")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRoomImageCommand = new DeleteRoomImageCommand() { Id = id };
            await _mediator.Send(deleteRoomImageCommand);
            return Ok();
        }
    }
}
