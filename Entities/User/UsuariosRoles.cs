namespace NET6_WEB_API_TEMPLATE_JWT.Entities.User
{
    public class UsuariosRoles
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
