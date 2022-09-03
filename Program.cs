using Microsoft.EntityFrameworkCore;
using NET6_WEB_API_TEMPLATE_JWT; 
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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
