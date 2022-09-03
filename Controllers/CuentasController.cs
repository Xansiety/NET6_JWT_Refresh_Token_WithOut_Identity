using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET6_WEB_API_TEMPLATE_JWT.DTOs;
using NET6_WEB_API_TEMPLATE_JWT.Helpers.Errors;
using NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces;

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
    }
}
