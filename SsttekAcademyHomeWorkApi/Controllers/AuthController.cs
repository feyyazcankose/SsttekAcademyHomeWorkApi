using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.Auth;
using SsttekAcademyHomeWorkApi.Models.Services.Auth;

namespace SsttekAcademyHomeWorkApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : CustomControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        return HandleServiceResult(await _authService.RegisterAsync(registerDto));
    }

    [HttpPost("Login")]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        return HandleServiceResult(await _authService.LoginAsync(loginDto));
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        return HandleServiceResult(await _authService.LogoutAsync());
    }
}
