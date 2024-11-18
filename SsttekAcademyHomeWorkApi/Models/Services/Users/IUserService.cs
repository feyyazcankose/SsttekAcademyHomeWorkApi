using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;

namespace SsttekAcademyHomeWorkApi.Models.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResult> CreateUserAsync(UserCreateDto dto);
        Task<ServiceResult<UserResponseDto>> GetUserByIdAsync(string id);
        Task<ServiceResult<List<UserResponseDto>>> GetAllUsersAsync();
        Task<ServiceResult> UpdateUserAsync(string id, UserUpdateDto dto);
        Task<ServiceResult> DeleteUserAsync(string id);
    }
}