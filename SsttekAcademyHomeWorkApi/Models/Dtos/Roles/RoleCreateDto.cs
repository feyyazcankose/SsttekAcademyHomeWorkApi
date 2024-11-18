using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SsttekAcademyHomeWorkApi.Models.Dtos.Roles;

public class RoleCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    [SwaggerSchema("Name of the role")]
    [DefaultValue("UpdatedUser")]
    public string Name { get; set; }
}