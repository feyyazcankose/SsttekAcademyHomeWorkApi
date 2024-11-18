using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.Auth;

namespace SsttekAcademyHomeWorkApi.Models.Services.Auth;

public interface IAuthService
{
    Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterDto model);
    Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginDto model);
    Task<ServiceResult> LogoutAsync();
}
