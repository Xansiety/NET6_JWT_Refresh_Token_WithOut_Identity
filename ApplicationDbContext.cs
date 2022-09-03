using Microsoft.EntityFrameworkCore;
using NET6_WEB_API_TEMPLATE_JWT.Entities.User;
using System.Reflection;

namespace NET6_WEB_API_TEMPLATE_JWT;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TI"); //SCHEMA CREATE
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //aplicar las configuraciones desde Folder FluentConfiguration
    }

    //ENTITIES ON DB
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; } 

}
