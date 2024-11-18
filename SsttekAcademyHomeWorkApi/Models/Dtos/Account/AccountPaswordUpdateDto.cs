using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.User
{
    public class AccountPasswordUpdateDto
    {
        [Required(ErrorMessage = "Current Password is required")]
        [SwaggerSchema("Your current password.")]
        [DataType(DataType.Password)]
        [DefaultValue("CurrentPass123")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [SwaggerSchema("The new password you want to set.")]
        [DataType(DataType.Password)]
        [DefaultValue("NewPass123")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [SwaggerSchema("Confirmation of the new password.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password do not match.")]
        [DefaultValue("NewPass123")]
        public string ConfirmPassword { get; set; }
    }
}