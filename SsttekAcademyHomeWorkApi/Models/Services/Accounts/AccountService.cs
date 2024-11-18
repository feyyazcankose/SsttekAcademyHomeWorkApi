using SsttekAcademyHomeWorkApi.Models.Repositories.Users;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.User;

namespace SsttekAcademyHomeWorkApi.Models.Services.Accounts;

public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<UserResponseDto>> GetProfileAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult<UserResponseDto>.ErrorResult("Kullanıcı bulunamadı.");

            var account = new UserResponseDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Id =   user.Id,
                PhoneNumber = user.PhoneNumber,
            };

            return ServiceResult<UserResponseDto>.SuccessResult(account);
        }

        public async Task<ServiceResult> UpdateProfileAsync(string userId, UserUpdateDto account)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            user.UserName = account.UserName;
            user.Email = account.Email;

            var result = await _userRepository.UpdateUserAsync(user);
            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Profil güncellenemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult("Profil başarıyla güncellendi.");
        }

        public async Task<ServiceResult> ChangePasswordAsync(string userId, UserPaswordUpdateDto model)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            var result = await _userRepository.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Şifre değiştirilemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult("Şifre başarıyla değiştirildi.");
        }
    }