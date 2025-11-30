using Application.Features.Identity.Users;
using Application.Features.Identity.Users.Commands;
using Application.Features.Identity.Users.Queries;
using Infrastructure.Constants;
using Infrastructure.Identity.Auth;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_v2.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        [HttpPost("register")]
        [ShouldHavePermission(SchoolAction.Create, SchoolFeature.Users)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] CreateUserRequest createUser)
        {
            var response = await Sender.Send(new CreateUserCommand { CreateUser = createUser });

            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [HttpPut("update")]
        [ShouldHavePermission(SchoolAction.Update, SchoolFeature.Users)]
        public async Task<IActionResult> UpdateUserDetailsAsync([FromBody] UpdateUserRequest updateUser)
        {
            var response = await Sender.Send(new UpdateUserCommand { UpdateUser = updateUser });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
        
        [HttpPut("update-status")]
        [ShouldHavePermission(SchoolAction.Update, SchoolFeature.Users)]
        public async Task<IActionResult> ChangeUserStatusAsync([FromBody] ChangeUserStatusRequest changeUserStatus)
        {
            var response = await Sender.Send(new UpdateUserStatusCommand { ChangeUserStatus = changeUserStatus });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
