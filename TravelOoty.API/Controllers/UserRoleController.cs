using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Authentication;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public UserRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchAsync([FromBody]UserRoleRequest userRole)
        {
            await _roleService.AddRoleToUserAsync(userRole.RoleName,userRole.UserId);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync([FromBody] UserRoleRequest userRole)
        {
            await _roleService.DeleteRoleAsync(userRole.RoleName, userRole.UserId);
            return Ok();
        }
    }
}
