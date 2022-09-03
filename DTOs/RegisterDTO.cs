using System.ComponentModel.DataAnnotations;

namespace NET6_WEB_API_TEMPLATE_JWT.DTOs;

public class RegisterDTO
{
    [Required]
    public string Nombres { get; set; }
    [Required]
    public string ApellidoPaterno { get; set; }
    [Required]
    public string ApellidoMaterno { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
