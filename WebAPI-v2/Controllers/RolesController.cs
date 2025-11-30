using Application.Features.Identity.Roles.Commands;
using Application.Features.Identity.Roles;
using Infrastructure.Constants;
using Infrastructure.Identity.Auth;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Identity.Roles.Queries;

namespace WebAPI_v2.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : BaseApiController
    {
        [HttpPost("add")]
        [ShouldHavePermission(SchoolAction.Create, SchoolFeature.Roles)]
        public async Task<IActionResult> AddRoleAsync([FromBody] CreateRoleRequest createRole)
        {
            var response = await Sender.Send(new CreateRoleCommand { CreateRole = createRole });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
