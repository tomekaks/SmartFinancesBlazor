using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Users.Dtos;
using SmartFinances.Application.Interfaces.Services;

namespace SmartFinances.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegisterRequest registerDto)
        {
            var response = await _authService.Register(registerDto);

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponse>> LoginAsync([FromBody] LoginRequest loginDto)
        {
            var response = await _authService.Login(loginDto);

            return Ok(response);
        }
    }
}
