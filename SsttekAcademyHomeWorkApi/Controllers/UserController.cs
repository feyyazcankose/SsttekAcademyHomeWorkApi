using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWorkApi.Models.Dtos.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;
using SsttekAcademyHomeWorkApi.Models.Services.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    [Route("api/user")]
    public class UserController : CustomControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Kullanıcı Ekleme (Create)
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create User",
            Description = "Creates a new user"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            return HandleServiceResult(await _userService.CreateUserAsync(dto));
        }

        // Kullanıcı Bilgilerini Görüntüleme (Read)
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get User",
            Description = "Get user info by ID"
        )]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(string id)
        {
            return HandleServiceResult(await _userService.GetUserByIdAsync(id));
        }

        // Kullanıcıları Listeleme
        [HttpGet]
        [SwaggerOperation(
            Summary = "List Users",
            Description = "Lists all users"
        )]
        [ProducesResponseType(typeof(List<UserResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            return HandleServiceResult(await _userService.GetAllUsersAsync());
        }

        // Kullanıcı Bilgilerini Güncelleme (Update)
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update User",
            Description = "Updates user info"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDto dto)
        {
            return HandleServiceResult(await _userService.UpdateUserAsync(id, dto));
        }

        // Kullanıcı Silme (Delete)
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete User",
            Description = "Deletes a user"
        )]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return HandleServiceResult(await _userService.DeleteUserAsync(id));
        }
    }
}
