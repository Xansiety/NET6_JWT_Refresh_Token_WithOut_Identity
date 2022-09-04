using System.ComponentModel.DataAnnotations;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.Entities.User;
public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
}
