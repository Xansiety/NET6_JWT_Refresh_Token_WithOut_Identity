using System.Text.Json.Serialization;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.DTOs;

public class ResponseAuth
{
    public string Mensaje { get; set; }
    public bool EstaAutenticado { get; set; }
    public string DisplayName { get; set; }
    public List<string> Roles { get; set; }
    public string AccessToken { get; set; }

    [JsonIgnore] //restringe que esta propiedad sea mostrada en la respuesta de json
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
}
