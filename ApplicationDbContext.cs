using Microsoft.EntityFrameworkCore;
using NET6_JWT_Refresh_Token_WithOut_Identity.Entities.User;
using System.Reflection;

namespace NET6_JWT_Refresh_Token_WithOut_Identity;
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
