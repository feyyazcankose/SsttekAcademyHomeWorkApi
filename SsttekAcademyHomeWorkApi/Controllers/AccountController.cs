using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;
using SsttekAcademyHomeWorkApi.Models.Services.Accounts;

namespace SsttekAcademyHomeWorkApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AccountController(IAccountService accountService) : CustomControllerBase
{
    [HttpGet("CurrentUser")]
    public async Task<IActionResult> CurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.GetProfileAsync(userId!));
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateAccount([FromBody] UserUpdateDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.UpdateProfileAsync(userId!,dto));
    }


    [HttpPatch("Password")]
    public async Task<IActionResult> ChangePassword(UserPaswordUpdateDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return HandleServiceResult(await accountService.ChangePasswordAsync(userId!,dto));
    }
}