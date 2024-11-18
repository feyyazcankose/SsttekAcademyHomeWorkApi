using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        [SwaggerSchema("Unique username for the user.")]
        [DefaultValue("SsttekUser")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [SwaggerSchema("Email address of the user.")]
        [DefaultValue("user@example.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [SwaggerSchema("Password for the user account.")]
        [DataType(DataType.Password)]
        [DefaultValue("Ssttek123")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [SwaggerSchema("Confirmation of the password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        [DefaultValue("Ssttek123")]
        public string ConfirmPassword { get; set; }
    }
}