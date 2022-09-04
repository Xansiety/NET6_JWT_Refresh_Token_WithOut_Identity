using NET6_JWT_Refresh_Token_WithOut_Identity.Entities.User;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.Entities.Auth;

public class RefreshToken
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsActive => Revoked == null && !IsExpired;
}
