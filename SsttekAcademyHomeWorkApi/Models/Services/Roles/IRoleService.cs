using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.Roles;

namespace SsttekAcademyHomeWorkApi.Models.Services.Roles
{
    public interface IRoleService
    {
        Task<ServiceResult> CreateRoleAsync(RoleCreateDto dto);
        Task<ServiceResult<List<RoleResponseDto>>> GetAllRolesAsync();
        Task<ServiceResult> UpdateRoleAsync(string id, RoleUpdateDto dto);
        Task<ServiceResult> DeleteRoleAsync(string id);
        Task<ServiceResult> AssignRoleToUserAsync(string userId, string roleName);
        Task<ServiceResult> RemoveRoleFromUserAsync(string userId, string roleName);
    }
}