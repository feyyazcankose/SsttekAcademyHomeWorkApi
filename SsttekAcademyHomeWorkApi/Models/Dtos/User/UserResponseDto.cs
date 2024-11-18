using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.User
{
    public class UserResponseDto
    {
        [SwaggerSchema("Unique identifier of the user.")]
        [DefaultValue("12345")]
        public string Id { get; set; }

        [SwaggerSchema("Username of the user.")]
        [DefaultValue("SsttekUser")]
        public string UserName { get; set; }

        [SwaggerSchema("Email address of the user.")]
        [DefaultValue("user@example.com")]
        public string Email { get; set; }

        [SwaggerSchema("Phone number of the user.")]
        [DefaultValue("+1234567890")]
        public string PhoneNumber { get; set; }
    }
}