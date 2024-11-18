namespace SsttekAcademyHomeWorkApi.Models.Services.Auth;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SsttekAcademyHomeWorkApi.Models.Commons;
using SsttekAcademyHomeWorkApi.Models.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    IConfiguration configuration)
    : IAuthService
{
    public async Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterDto model)
    {
        var user = new IdentityUser { UserName = model.Username, Email = model.Email };
        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            var token = GenerateJwtToken(user);
            var response = new AuthResponseDto
            {
                AccessToken = token
            };
            return ServiceResult<AuthResponseDto>.SuccessResult(response, "Kayıt başarılı.");
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return ServiceResult<AuthResponseDto>.ErrorResult("Kayıt başarısız.", errors);
        }
    }

    public async Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginDto model)
    {
        var result = await signInManager.PasswordSignInAsync(
            model.Username, model.Password, model.RememberMe, false);

        if (result.Succeeded)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            var token = GenerateJwtToken(user);
            var response = new AuthResponseDto
            {
                AccessToken = token
            };
            return ServiceResult<AuthResponseDto>.SuccessResult(response, "Giriş başarılı.");
        }
        
        return ServiceResult<AuthResponseDto>.ErrorResult("Geçersiz kullanıcı adı veya şifre.");
    }

    public async Task<ServiceResult> LogoutAsync()
    {
        await signInManager.SignOutAsync();
        return ServiceResult.SuccessResult("Çıkış yapıldı.");
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
            // Ek claim'ler eklenebilir
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["Expires"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
