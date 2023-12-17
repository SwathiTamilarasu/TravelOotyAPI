using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Profile;
using TravelOoty.Identity.Interface;

namespace TravelOoty.API.Controllers
{
    
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<List<UserResponse>> Get()
        {
            return await _userService.GetAllAsync(true);
            
        }
        [HttpGet("GetUserByIdAysnc")]
        public async Task<ActionResult<UserResponse>> GetUserByIdAysnc(string id)
        {
            return Ok(await _authenticationService.GetUserById(id));
        }

        [HttpGet("GetEmployeeAysnc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<UserResponse>> GetEmployeeAysnc()
        {
            return await _userService.GetAllAsync(true);
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> Delete(string id)
        {

            return Ok(await _authenticationService.DeleteUser(id));
        }
    }
}
