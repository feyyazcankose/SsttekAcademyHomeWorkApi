using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.User;

public class UserCreateDto
{
    [SwaggerSchema("Username of the user.")]
    [DefaultValue("SsttekUser")]
    public string UserName { get; set; }

    [SwaggerSchema("Email address of the user.")]
    [DefaultValue("user@example.com")]
    public string Email { get; set; }

    [SwaggerSchema("Phone number of the user.")]
    [DefaultValue("+1234567890")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [SwaggerSchema("Password used to log in.")]
    [DefaultValue("Ssttek123")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}