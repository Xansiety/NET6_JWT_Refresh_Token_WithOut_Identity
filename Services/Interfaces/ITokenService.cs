using NET6_WEB_API_TEMPLATE_JWT.DTOs;

namespace NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces
{
    public interface ITokenService
    {
        Task<ResponseAuth> GenerateAccessTokenAsync(UserCredentials model);
        Task<ResponseAuth> RefreshTokenAsync(string refreshToken);
    }
}
