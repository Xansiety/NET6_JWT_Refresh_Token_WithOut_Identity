namespace NET6_WEB_API_TEMPLATE_JWT.Helpers.AuthTools
{
    public class Autorizacion
    {
        public enum AuthorizationRoles
        {
            Admin,
            Gerente,
            Empleado
        }

        public const AuthorizationRoles rol_predeterminado = AuthorizationRoles.Admin;
    }
}
