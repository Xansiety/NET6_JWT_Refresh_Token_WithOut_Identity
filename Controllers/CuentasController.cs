using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6_WEB_API_TEMPLATE_JWT.DTOs;
using NET6_WEB_API_TEMPLATE_JWT.Helpers.Errors;
using NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces;
using NET6_WEB_API_TEMPLATE_JWT.Services.Repository;

namespace NET6_WEB_API_TEMPLATE_JWT.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public CuentasController(ILogger<WeatherForecastController> logger, IUserService userService, ITokenService tokenService)
        {
            _logger = logger;
            this.userService = userService;
            this.tokenService = tokenService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDTO model)
        {
            try
            {
                var result = await userService.RegisterAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw new Exception();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserCredentials userInfo)
        {
            try
            {
                var response = await tokenService.GenerateAccessTokenAsync(userInfo);
                if (response.RefreshToken is not null)
                {
                    SetRefreshTokenInCookie(response.RefreshToken);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Ok(ex);
            } 
        }


        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await tokenService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }



        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            await userService.revokeRefreshToken(); 
            return Ok();
        }


        //asignamos el refresh token en mi cookie de solo http
        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

    }
}
