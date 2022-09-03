using Microsoft.AspNetCore.Mvc;
using NET6_WEB_API_TEMPLATE_JWT.Helpers.Errors;
namespace NET6_WEB_API_TEMPLATE_JWT.Controllers;

[Route("errors/{code}")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ResponseAPI(code));
    }
}