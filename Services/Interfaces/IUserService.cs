using NET6_JWT_Refresh_Token_WithOut_Identity.DTOs;
using NET6_JWT_Refresh_Token_WithOut_Identity.Entities.User;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.Services.Interfaces
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
