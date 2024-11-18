using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Auth;

public class AuthResponseDto
{
    [Required]
    [Display(Name = "Access Token", Description = "Yetkilendirme için kullanacağınız JWT token.")]
    [DefaultValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...")]
    public string AccessToken { get; set; }
}