using NET6_WEB_API_TEMPLATE_JWT.DTOs;
using NET6_WEB_API_TEMPLATE_JWT.Entities.User;

namespace NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> GetByRefreshTokenAsync(string refreshToken);
        Task<Usuario> GetByUserNameAsync(string username);
        Task<string> RegisterAsync(RegisterDTO registerDto); 
        Task revokeRefreshToken();
        Task<Usuario> ValidateUserAync(UserCredentials userCredentials);
    }
}
