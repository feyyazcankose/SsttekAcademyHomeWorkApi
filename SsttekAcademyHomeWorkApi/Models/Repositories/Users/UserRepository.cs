using Microsoft.AspNetCore.Identity;

namespace SsttekAcademyHomeWorkApi.Models.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private IUserRepository _userRepositoryImplementation;

    public UserRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> ChangePasswordAsync(IdentityUser user, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }
}