namespace NET6_JWT_Refresh_Token_WithOut_Identity.Helpers.Errors;

public class ExceptionAPI : ResponseAPI
{
    public ExceptionAPI(int statusCode, string message = null, string details = null) : base(statusCode, message)
    {
        Details = details;
    }
    public string Details { get; set; }
}
