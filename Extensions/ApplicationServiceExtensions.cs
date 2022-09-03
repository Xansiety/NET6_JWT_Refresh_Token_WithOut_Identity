namespace NET6_WEB_API_TEMPLATE_JWT.Extensions;

public static class ApplicationServiceExtensions
{ 
    //CORS
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin() //WithOrigins("https://dominio.com")
            .AllowAnyMethod() // WithMethods("Get,Post")
            .AllowAnyHeader()); //WithHeaders("accept", "content-type")
        });



}
