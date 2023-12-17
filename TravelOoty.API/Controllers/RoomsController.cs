using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Rooms.Command.CreateRoom;
using TravelOoty.Application.Features.Rooms.Command.DeleteRoom;
using TravelOoty.Application.Features.Rooms.Command.UpdateRoom;
using TravelOoty.Application.Features.Rooms.Query;
using TravelOoty.Application.Features.Rooms.Query.GetAllRooms;
using TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByBooking;
using TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByPropertyId;
using TravelOoty.Application.Features.Rooms.Query.GetRoomByUserId;
using TravelOoty.Application.Features.RoomsImageDetails.Command;
using TravelOoty.Application.Models.Profile;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<RoomVM>>> GetAllRooms()
        {           
            var dtos = await _mediator.Send(new GetAllRoomQuery());
            return Ok(dtos);        
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RoomVM>>> GetRoomById(string id)
        {
                    
            var dtos = await _mediator.Send(new GetRoomQuery(id));
            return Ok(dtos);
        }
        [HttpGet("UserId",Name = "GetAllRoomsByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RoomVM>>> GetRoomByUserId(Guid userId)
        {           
            var dtos = await _mediator.Send(new GetRoomQueryByUser(userId.ToString()));
            if (dtos.Count > 0)
            {
                return Ok(dtos);
            }
            else
            {
                return Ok("Approval process is in progress");
            }

        }
        [HttpGet("PropertyId", Name = "GetAllRoomsByProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RoomVM>>> GetRoomByPropertyId(string propertyId)
        {
            var dtos = await _mediator.Send(new GetRoomQueryByProperty(propertyId));
            if (dtos.Count > 0)
            {
                return Ok(dtos);
            }
            else
            {
                return Ok("Approval process is in progress");
            }

        }

        [HttpGet("GetRoomByPropertyDate/{propertyId}/{fromDate}/{toDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RoomVM>>> GetRoomByPropertyDate(string propertyId, DateTime fromDate, DateTime toDate)
        {
            var dtos = await _mediator.Send(new GetRoomQueryByDate(propertyId, fromDate, toDate));
            if (dtos.Count > 0)
            {
                return Ok(dtos);
            }
            else
            {
                return Ok("Approval process is in progress");
            }

        }

        [HttpPost]
        public async Task<ActionResult<CreateRoomResponse>> Create([FromBody] CreateRoomCommand createRoomCommand)
        {
            var response = await _mediator.Send(createRoomCommand);   
            
            return response;
        }

        [HttpPut]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoomCommand updateRoomCommand)
        {
            await _mediator.Send(updateRoomCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRoomCommand = new DeleteRoomCommand() { RoomId = id };
            await _mediator.Send(deleteRoomCommand);
            return Ok();
        }

      
    }
}
