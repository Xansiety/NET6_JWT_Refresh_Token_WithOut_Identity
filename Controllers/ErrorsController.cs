using Microsoft.AspNetCore.Mvc;
using NET6_JWT_Refresh_Token_WithOut_Identity.Helpers.Errors;
namespace NET6_JWT_Refresh_Token_WithOut_Identity.Controllers;

[Route("errors/{code}")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ResponseAPI(code));
    }
}