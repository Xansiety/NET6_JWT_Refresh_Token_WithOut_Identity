using System.ComponentModel.DataAnnotations;

namespace NET6_WEB_API_TEMPLATE_JWT.Entities.User;
public class Rol
{ 
    public int Id { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
}
