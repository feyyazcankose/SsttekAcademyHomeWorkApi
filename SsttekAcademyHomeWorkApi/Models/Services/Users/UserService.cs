using Microsoft.AspNetCore.Identity;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;
using SsttekAcademyHomeWorkApi.Models.Repositories.Users;

namespace SsttekAcademyHomeWorkApi.Models.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<ServiceResult> CreateUserAsync(UserCreateDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return ServiceResult.ErrorResult("Kullanıcı oluşturulamadı.", result.Errors.Select(e => e.Description).ToList());
            }

            return ServiceResult.SuccessResult(StatusCodes.Status201Created);
        }

        public async Task<ServiceResult<UserResponseDto>> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return ServiceResult<UserResponseDto>.ErrorResult("Kullanıcı bulunamadı.");

            var dto = new UserResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return ServiceResult<UserResponseDto>.SuccessResult(dto);
        }

        public async Task<ServiceResult<List<UserResponseDto>>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();

            var dtoList = users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).ToList();

            return ServiceResult<List<UserResponseDto>>.SuccessResult(dtoList);
        }

        public async Task<ServiceResult> UpdateUserAsync(string id, UserUpdateDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Kullanıcı güncellenemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status204NoContent);
        }

        public async Task<ServiceResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Kullanıcı silinemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult(StatusCodes.Status204NoContent);
        }
    }
}
