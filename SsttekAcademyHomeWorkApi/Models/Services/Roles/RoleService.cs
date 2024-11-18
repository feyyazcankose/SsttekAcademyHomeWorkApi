using Microsoft.AspNetCore.Identity;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.Roles;

namespace SsttekAcademyHomeWorkApi.Models.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ServiceResult> CreateRoleAsync(RoleCreateDto dto)
        {
            var role = new IdentityRole { Name = dto.Name };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Rol oluşturulamadı.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status201Created);


        }

        public async Task<ServiceResult<List<RoleResponseDto>>> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles.ToList();

            var dtoList = roles.Select(r => new RoleResponseDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return ServiceResult<List<RoleResponseDto>>.SuccessResult(dtoList);
        }

        public async Task<ServiceResult> UpdateRoleAsync(string id, RoleUpdateDto dto)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return ServiceResult.ErrorResult("Rol bulunamadı.");

            role.Name = dto.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Rol güncellenemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status204NoContent);
        }

        public async Task<ServiceResult> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return ServiceResult.ErrorResult("Rol bulunamadı.");

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Rol silinemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status204NoContent);
        }

        public async Task<ServiceResult> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Rol ataması yapılamadı.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status201Created);
            
        }

        public async Task<ServiceResult> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Rol kaldırılamadı.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status204NoContent);

        }
    }
}
