using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.Roles;
using SsttekAcademyHomeWorkApi.Models.Services.Roles;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    [Route("api/role")]
    public class RoleController : CustomControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // Rol Ekleme (Create Role)
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create Role",
            Description = "Creates a new role"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto dto)
        {
            return HandleServiceResult(await _roleService.CreateRoleAsync(dto));
        }

        // Rolleri Listeleme (List Roles)
        [HttpGet]
        [SwaggerOperation(
            Summary = "List Roles",
            Description = "Lists all roles"
        )]
        [ProducesResponseType(typeof(List<RoleResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListRoles()
        {
            return HandleServiceResult(await _roleService.GetAllRolesAsync());
        }

        // Rol Güncelleme (Update Role)
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Role",
            Description = "Updates a role"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleUpdateDto dto)
        {
            return HandleServiceResult(await _roleService.UpdateRoleAsync(id, dto));
        }

        // Rol Silme (Delete Role)
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Role",
            Description = "Deletes a role"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteRole(string id)
        {
            return HandleServiceResult(await _roleService.DeleteRoleAsync(id));
        }

        // Kullanıcıya Rol Atama (Assign Role)
        [HttpPost("assign")]
        [SwaggerOperation(
            Summary = "Assign Role to User",
            Description = "Assigns a role to a user"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleDto dto)
        {
            return HandleServiceResult(await _roleService.AssignRoleToUserAsync(dto.UserId, dto.RoleName));
        }

        // Kullanıcıdan Rol Kaldırma (Remove Role)
        [HttpPost("remove")]
        [SwaggerOperation(
            Summary = "Remove Role from User",
            Description = "Removes a role from a user"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] AssignRoleDto dto)
        {
            return HandleServiceResult(await _roleService.RemoveRoleFromUserAsync(dto.UserId, dto.RoleName));
        }
    }
}
