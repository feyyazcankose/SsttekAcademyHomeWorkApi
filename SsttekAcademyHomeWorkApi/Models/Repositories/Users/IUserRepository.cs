using Microsoft.AspNetCore.Identity;

namespace SsttekAcademyHomeWorkApi.Models.Repositories.Users;

public interface IUserRepository
{
    Task<IdentityUser> GetUserByIdAsync(string userId);
    Task<IdentityResult> UpdateUserAsync(IdentityUser user);
    Task<IdentityResult> ChangePasswordAsync(IdentityUser user, string currentPassword, string newPassword);
}