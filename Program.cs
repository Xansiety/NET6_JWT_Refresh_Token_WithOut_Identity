using Microsoft.EntityFrameworkCore;
using NET6_JWT_Refresh_Token_WithOut_Identity;
using NET6_JWT_Refresh_Token_WithOut_Identity.Extensions;
using NET6_JWT_Refresh_Token_WithOut_Identity.Middlewares;
using Serilog; //Serilog.AspNetCore Package

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// SeriLog->Configuración obtenida desde AppSettings
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

//DB->CONNECTION
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//SERILOG ->LOGGER
builder.Logging.AddSerilog(logger: logger);
// CORS
builder.Services.ConfigureCors();
//Dependency Injection
builder.Services.AddAplicationServices();
// JWT
builder.Services.AddJwt(configuration: builder.Configuration);
// HTTP HttpContextAccessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
//MiddleWare para manejo de excepciones de forma global
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");//lamamos a un controlador  //nos permite generar paginas de error personalizadas cuando ocurre un error 
 
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
