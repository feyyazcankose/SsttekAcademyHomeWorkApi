using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.Auth;
using SsttekAcademyHomeWorkApi.Models.Dtos.Commons;
using SsttekAcademyHomeWorkApi.Models.Services.Auth;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Controllers;

[ApiController]
[ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
[Route("api/auth")]
public class AuthController : CustomControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Register",
        Description = "Users registration action"
    )]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        return HandleServiceResult(await _authService.RegisterAsync(registerDto));
    }

    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login",
        Description = "Users login action"
    )]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        return HandleServiceResult(await _authService.LoginAsync(loginDto));
    }

    [HttpPost("logout")]
    [SwaggerOperation(
        Summary = "Logout",
        Description = "Users logout action"
    )]
    public async Task<IActionResult> Logout()
    {
        return HandleServiceResult(await _authService.LogoutAsync());
    }
}
