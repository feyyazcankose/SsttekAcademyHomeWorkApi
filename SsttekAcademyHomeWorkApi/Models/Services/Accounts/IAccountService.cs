using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;

namespace SsttekAcademyHomeWorkApi.Models.Services.Accounts;

public interface IAccountService
{
    Task<ServiceResult<UserResponseDto>> GetProfileAsync(string userId);
    Task<ServiceResult> UpdateProfileAsync(string userId, UserUpdateDto account);
    Task<ServiceResult> ChangePasswordAsync(string userId, UserPaswordUpdateDto model);
}