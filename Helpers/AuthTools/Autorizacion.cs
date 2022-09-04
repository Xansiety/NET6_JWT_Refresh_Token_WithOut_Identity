namespace NET6_JWT_Refresh_Token_WithOut_Identity.Helpers.AuthTools
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
