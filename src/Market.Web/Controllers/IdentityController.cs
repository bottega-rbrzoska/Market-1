using System;
using System.Threading.Tasks;
using Market.Application.Users.Commands;
using Market.Application.Users.DTO;
using Market.Application.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Market.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> Me()
            => await _identityService.GetAsync(Guid.Empty);

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(SignUp command)
        {
            await _identityService.SignUpAsync(command);

            return NoContent();
        }
        
        [HttpPost("sign-in")]
        public async Task<ActionResult<string>> SignIn(SignIn command)
        {
            await _identityService.SignInAsync(command);

            return Ok(string.Empty);
        }
    }
}