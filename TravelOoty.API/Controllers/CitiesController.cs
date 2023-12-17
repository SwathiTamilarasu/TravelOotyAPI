using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Features.City.Command.CreateCity;
using TravelOoty.Application.Features.City.Query.GetCity;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<CityListVM>>> GetAllCiteis()
        {
            var dtos = await _mediator.Send(new GetCityQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCities")]
        public async Task<ActionResult<CreateCityResponse>> Create([FromBody] CreateCityCommand createHotelCommand)
        {
            var response = await _mediator.Send(createHotelCommand);
            return response;
        }
    }
}
