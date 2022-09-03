using Microsoft.EntityFrameworkCore;
using NET6_WEB_API_TEMPLATE_JWT;
using NET6_WEB_API_TEMPLATE_JWT.Extensions;
using NET6_WEB_API_TEMPLATE_JWT.Middlewares;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
