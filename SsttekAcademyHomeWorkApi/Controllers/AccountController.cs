using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.Account;
using SsttekAcademyHomeWorkApi.Models.Dtos.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;
using SsttekAcademyHomeWorkApi.Models.Services.Accounts;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Controllers;

[Authorize]
[ApiController]
[ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
[Route("api/account")]
public class AccountController(IAccountService accountService) : CustomControllerBase
{
    [HttpGet("current")]
    [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Current User",
        Description = "Get user info"
    )]
    public async Task<IActionResult> CurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.GetProfileAsync(userId!));
    }

    [HttpPut()]
    [SwaggerOperation(
        Summary = "Update Account",
        Description = "Update account"
    )]
    public async Task<IActionResult> UpdateAccount([FromBody] AccountUpdateDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.UpdateProfileAsync(userId!,dto));
    }


    [HttpPatch("password")]
    [SwaggerOperation(
        Summary = "Update Password",
        Description = "Update password"
    )]
    public async Task<IActionResult> ChangePassword(AccountPasswordUpdateDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.ChangePasswordAsync(userId!,dto));
    }
}