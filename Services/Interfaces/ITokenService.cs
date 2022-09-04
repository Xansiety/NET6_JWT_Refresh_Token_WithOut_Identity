using NET6_JWT_Refresh_Token_WithOut_Identity.DTOs;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.Services.Interfaces
{
    public interface ITokenService
    {
        Task<ResponseAuth> GenerateAccessTokenAsync(UserCredentials model);
        Task<ResponseAuth> RefreshTokenAsync(string refreshToken);
    }
}
