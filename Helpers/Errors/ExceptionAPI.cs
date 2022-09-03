namespace NET6_WEB_API_TEMPLATE_JWT.Helpers.Errors;

public class ExceptionAPI : ResponseAPI
{
    public ExceptionAPI(int statusCode, string message = null, string details = null) : base(statusCode, message)
    {
        Details = details;
    }
    public string Details { get; set; }
}
