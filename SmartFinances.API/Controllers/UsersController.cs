using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Users.Dtos;
using SmartFinances.Application.Interfaces.Services;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            await _authService.Register(registerDto);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);

            return Ok(response);
        }
    }
}
