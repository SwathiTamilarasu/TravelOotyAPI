using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TravelOoty.API.Model;
using TravelOoty.API.Utility;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Features.Amenities.Commands.DeleteAmenities;
using TravelOoty.Application.Features.Property.Command.CreateProperty;
using TravelOoty.Application.Features.Property.Command.DeleteProperty;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetApprovedProp;
using TravelOoty.Application.Features.Property.Query.GetProperty;
using TravelOoty.Application.Features.Property.Query.GetPropertyById;
using TravelOoty.Application.Features.Property.Query.GetPropertyByName;
using TravelOoty.Application.Features.Property.Query.GetPropertyByUserId;
using TravelOoty.Application.Features.Property.Query.GetPropertyInfoById;
using TravelOoty.Application.Features.Property.Query.GetUpdatePropertyById;
using TravelOoty.Application.Features.PropertyAmenitiesLink.Command;
using TravelOoty.Application.Features.Rooms.Command.CreateRoom;
using TravelOoty.Infrastructure.FileUpload;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        IWebHostEnvironment _env;
        public PropertyController(IMediator mediator, IRoleService roleService, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
            _roleService = roleService;
        }
        //[Authorize]
        [HttpGet("all", Name = "GetAllProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<PropertyListVM>>> GetAllProperty()
        {
            var filter = Request.Query["filter"];
            var dtos = await _mediator.Send(new GetPropertyQuery(filter));
            return Ok(dtos);
        }

        [HttpGet(Name ="GetApprovedProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PropertyListVM>>> GetApprovedProperty()
        {
            var filter = Request.Query["filter"];
            var dtos = await _mediator.Send(new GetApprovedPropQuery(filter));
            return Ok(dtos);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PropertyListVM>>> GetPropertyByUserId(string userId)
        {
            var dtos = await _mediator.Send(new GetPropQueryByUserId(userId));
            return Ok(dtos);
        }
        [HttpGet("{name}/properties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PropertyListVM>>> GetPropertyByName(string name)
        {
            var dtos = await _mediator.Send(new GetPropQueryName(name));
            return Ok(dtos);
        }

        [HttpGet("GetPropertyById/{propertyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PropertyListVM>>> GetPropertyById(int propertyId)
        {
            var dtos = await _mediator.Send(new GetPropInfoQueryId(propertyId));
            return Ok(dtos);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<UpdatePropertyCommand> patchState)
        {
            var getPropertyCommand = new GetUpdatePropertyId(id);
            
            var dtos = await _mediator.Send(getPropertyCommand);
            if (dtos == null)
            {
                return NotFound();
            }
            
            patchState.ApplyTo(dtos, ModelState);
            if (!TryValidateModel(dtos))
            {
                return ValidationProblem(ModelState);
            }            
            var result= await _mediator.Send(dtos);
             
            return Ok(result);

        }


        [HttpPost(Name = "AddProperty")]
        public async Task<ActionResult<CreatePropertyResponse>> Create([FromForm] PropertyModel createHotelCommand)
        {
            var myRoomLists = new List<RoomDto>();
            var amenitiesJoins = new List<PropertyAmenitiesLinkDto>();
            if (!string.IsNullOrEmpty(createHotelCommand.Rooms))
            { 
                myRoomLists = JsonConvert.DeserializeObject<List<RoomDto>>(createHotelCommand.Rooms);
            }
            if (!string.IsNullOrEmpty(createHotelCommand.AmenitiesJoins))
            {
                amenitiesJoins = JsonConvert.DeserializeObject<List<PropertyAmenitiesLinkDto>>(createHotelCommand.AmenitiesJoins);
            }
            CreatePropertyCommand command = new CreatePropertyCommand();
            command.PhoneNumber = createHotelCommand.PhoneNumber;
            command.Rooms = myRoomLists;
            command.ApprovalStatus = createHotelCommand.ApprovalStatus;
            command.Address = createHotelCommand.Address;
            command.CityId = createHotelCommand.CityId;
            command.File = createHotelCommand.File;
            command.CreatedBy = createHotelCommand.CreatedBy;
            command.Email = createHotelCommand.Email;
            command.Name = createHotelCommand.Name;
            command.PackageName = createHotelCommand.PackageName;
            command.PhoneNumber = createHotelCommand.PhoneNumber;
            command.AmenitiesJoins = amenitiesJoins;
            command.PropertyTypeId = createHotelCommand.PropertyTypeId;
            command.PropertyID = createHotelCommand.PropertyID;
            command.PropertierName = createHotelCommand.PropertierName;
            command.TotalRooms = createHotelCommand.TotalRooms;
            command.PostalCode = createHotelCommand.PostalCode;
            command.CheckInOut = createHotelCommand.CheckInOut;
            command.FrontDeskTime = createHotelCommand.FrontDeskTime;
            command.AccountNumber = createHotelCommand.AccountNumber;
            command.AccountName = createHotelCommand.AccountName;
            command.IfscCode = createHotelCommand.IfscCode;
            command.PropertyDesc = createHotelCommand.PropertyDesc;
            command.Tax = createHotelCommand.Tax;
            command.IsActive= createHotelCommand.IsActive;
            var response = await _mediator.Send(command);
            //  await _roleService.AddRoleToUserAsync(RoleEnum.Role.Admin.ToString(), response.PropertyDto.CreatedBy);
            return response;
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] TravelOoty.Application.Features.Property.Command.UpdateProperty.UpdatePropertyCmd updateHotelCommand)
        {
            var response = await _mediator.Send(updateHotelCommand);
            //await _roleService.AddRoleToUserAsync(RoleEnum.Role.Admin.ToString(), response.PropertyDto.CreatedBy);
            return Ok();
        }
        [HttpDelete("{id}", Name = "DeleteProperty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeletePropertyCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
