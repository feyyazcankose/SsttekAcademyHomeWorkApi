using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Username is required")]
        [SwaggerSchema("New username for the user.")]
        [DefaultValue("UpdatedUser")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [SwaggerSchema("New email address of the user.")]
        [DefaultValue("updateduser@example.com")]
        public string Email { get; set; }

        [SwaggerSchema("New phone number of the user.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [DefaultValue("+0987654321")]
        public string PhoneNumber { get; set; }
    }
}