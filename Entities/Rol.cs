using System.ComponentModel.DataAnnotations;
namespace NET6_WEB_API_TEMPLATE_JWT.Entities;
public class Rol
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool Active { get; set; }
}
