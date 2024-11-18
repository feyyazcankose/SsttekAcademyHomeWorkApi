using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Roles;

public class AssignRoleDto
{
    [SwaggerSchema("Unique identifier of the user.")]
    [DefaultValue("63327db7-943b-4a8a-9f7f-f0b4bcaa6db3")]
    public string UserId { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [SwaggerSchema("Name of the role")]
    [DefaultValue("UpdatedUser")]
    public string RoleName { get; set; }
}