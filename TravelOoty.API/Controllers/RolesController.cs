using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Authentication;

namespace TravelOoty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<RoleRequest> Get()
        {
            var result = _roleService.GetAllRoles();
            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync([FromBody]RoleRequest role)
        {
            await _roleService.AddRoleAsync(role.Name);
            return Ok();
        }
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Patch([FromBody] RoleRequest role)
        {
             await _roleService.AddRoleAsync(role.Name);
            return Ok();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] RoleRequest role)
        {
            await _roleService.DeleteRoleAsync(role.Id,role.Name);
            return Ok();
        }
     
    }
}
