using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features;
using TravelOoty.Application.Features.Hotels.Commands.CreateHotel;
using TravelOoty.Application.Features.Hotels.Queries.GetHotelExport;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all",Name ="GetAllHotels")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<HotelsListVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetHotelsListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name ="AddHotel")]
        public async Task<ActionResult<CreateHotelCommandResponse>> Create([FromBody] CreateHotelCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }

        [HttpGet("export",Name ="ExportEvents")]
        public async Task<FileResult> ExportHotels()
        {
            var fileDto = await _mediator.Send(new GetHotelExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.FileName);
        }
    }
}
