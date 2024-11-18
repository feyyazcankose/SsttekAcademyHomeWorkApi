using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        [SwaggerSchema("Username used to log in.")]
        [DefaultValue("ssttek")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [SwaggerSchema("Password used to log in.")]
        [DefaultValue("Ssttek123")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [SwaggerSchema("Indicates whether to remember the user on this device.")]
        public bool RememberMe { get; set; }
    }
}