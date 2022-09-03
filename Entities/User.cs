namespace NET6_WEB_API_TEMPLATE_JWT.Entities;
public class User
{
    public int Id { get; set; } = 1;
    public string Email { get; set; }
    public string Password { get; set; }
     
    //refresh Token
    public string RefreshToken { get; set; } = null;
    public DateTime? CreatedrefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    // Tiempo de vida de refresh Token 
    public bool IsExpiredRefreshToken => DateTime.UtcNow >= RefreshTokenExpiryTime && RefreshTokenExpiryTime != null;
    //revoked
    //public DateTime? RevokedRefreshToken { get; set; }
    public bool IsActiveRefreshToken => RefreshToken != null && !IsExpiredRefreshToken;
     
    public int? UserCreate { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool Active { get; set; }
}
